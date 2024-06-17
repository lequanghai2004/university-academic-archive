import tensorflow_datasets as tfds
import matplotlib as plt
import tensorflow as tf

dataset, dataset_info = tfds.load(
    'malaria', with_info=True, as_supervised=True, shuffle_files=True, split=['train'])
# Convert the dataset to a TensorFlow dataset object (if it's not already)
if isinstance(dataset, list):
    dataset = dataset[0]

# Define ratios for splitting the dataset
TRAIN_RATIO = 0.8
VALIDATION_RATIO = 0.1
TEST_RATIO = 0.1
IMAGE_SIZE = 224

# Get the total length of the dataset
dataset_len = dataset.cardinality().numpy()

# Calculate the number of samples for each split
train_data_len = int(TRAIN_RATIO * dataset_len)
validation_data_len = int(VALIDATION_RATIO * dataset_len)
test_data_len = int(TEST_RATIO * dataset_len)

# Shuffle the dataset
dataset = dataset.shuffle(
    buffer_size=dataset_len,
    reshuffle_each_iteration=False)

# Split the dataset into training, validation, and test sets
train_data = dataset.take(train_data_len)
validation_data = dataset.skip(train_data_len).take(validation_data_len)
test_data = dataset.skip(
    train_data_len + validation_data_len).take(test_data_len)

dataset = dataset.map(lambda image, label: (
    tf.image.resize(image, (IMAGE_SIZE, IMAGE_SIZE)) / 255.0, label))
# Shuffle and batch the dataset
dataset = dataset.shuffle(buffer_size=1000).batch(1)

# Define the model
model = tf.keras.Sequential([
    tf.keras.Input(shape=(224, 224, 3)),
    tf.keras.layers.Conv2D(
        filters=6,
        kernel_size=5,
        strides=1,
        padding='valid',
        activation='relu'),
    tf.keras.layers.MaxPooling2D(pool_size=2, strides=2),
    tf.keras.layers.Conv2D(
        filters=16,
        kernel_size=5,
        strides=1,
        padding='valid',
        activation='relu'),
    tf.keras.layers.MaxPooling2D(pool_size=2, strides=2),
    tf.keras.layers.Flatten(),
    tf.keras.layers.Dense(256, activation='relu'),
    tf.keras.layers.Dense(32, activation='relu'),
    tf.keras.layers.Dense(1, activation='relu'),
])

model.compile(
    optimizer='adam',
    loss='binary_crossentropy',
    metrics=['accuracy'])

fit_result = model.fit(
    train_data,
    validation_data=validation_data,
    epochs=50,
    verbose=1)

model.save('cnn_malaria_detection')

from matplotlib import pyplot as p
p.plot(fit_result.history['loss'])
p.plot(fit_result.history['val_loss'])
p.title('Model Loss')
p.ylabel('Loss')
p.xlabel('Epoch')
p.legend(['Train', 'Validation'], loc='upper left')
p.show()


