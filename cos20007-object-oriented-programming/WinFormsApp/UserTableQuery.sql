DROP TABLE users;
DROP TABLE persons;
DROP TABLE staffs;
DROP TABLE orders;
----
----
CREATE TABLE users (
    id INT IDENTITY PRIMARY KEY,
    username NVARCHAR(100) UNIQUE,
    salt_pwd SMALLINT,
    password VARBINARY(32) NOT NULL,
    priority INT NOT NULL,
    --
    fullname NVARCHAR(255),
    email NVARCHAR(100),
    phone_no NVARCHAR(20),
    --
);
CREATE INDEX idx_username ON users(username);
----
CREATE TABLE staffs (
    id INT PRIMARY KEY,
    role NVARCHAR(100),
    status NVARCHAR(100),
    current_branch NVARCHAR(255),
    -- 
    FOREIGN KEY (id) REFERENCES users(id)
);
CREATE TABLE orders (
    id INT IDENTITY PRIMARY KEY,
    customer_id INT,
    staff_id INT,
    date_time DATETIME NOT NULL DEFAULT GETDATE(),
    approach INT NOT NULL
    --
    FOREIGN KEY (customer_id) REFERENCES users(id),
    FOREIGN KEY (staff_id) REFERENCES users(id)
);
CREATE TABLE items (
    id INT IDENTITY PRIMARY KEY,
    title NVARCHAR(255) UNIQUE,
    description NVARCHAR(MAX),
    types NVARCHAR(255),
    options NVARCHAR(MAX),
    price_vnd DECIMAL(10, 2) NOT NULL,
);
CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    options INT NOT NULL DEFAULT 0000,
    amount INT NOT NULL DEFAULT 1,
    --
    PRIMARY KEY (order_id, item_id, options)
);
----
----