#include <iostream>
#include <vector>

class IObserver
{
public:
    virtual void Update() = 0;
};

class IObservable
{
public:
    virtual void AddObserver(IObserver* observer) = 0;
    virtual void RemoveObserver(IObserver* observer) = 0;
    virtual void NotifyObservers() = 0;
};

class Subject : public IObservable, public IObserver
{
private:
    std::vector<IObserver*> observers;

public:
    void AddObserver(IObserver* observer) override
    {
        observers.push_back(observer);
    }

    void RemoveObserver(IObserver* observer) override
    {
        // Implementation of removal logic - identify position then erase
    }

    void NotifyObservers() override
    {
        for (IObserver* observer : observers)
        {
            observer->Update();
        }
    }

    void Update() override
    {
        // Implementation of update logic
    }
};

int main()
{
    // Creating a Subject object
    Subject subject;

    // Creating an observer
    IObserver* observer = &subject;

    // Registering the observer with the subject
    subject.AddObserver(observer);

    // Notifying observers
    subject.NotifyObservers();

    return 0;
}
