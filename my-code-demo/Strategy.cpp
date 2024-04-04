#include <iostream>
#include <memory>

class IFlyStrategy
{
public:
    virtual void fly() = 0;
};

class FlyNowhere : public IFlyStrategy
{
public:
    void fly() override
    {
        std::cout << "I can't fly." << std::endl;
    }
};

// =========================================================== //

class IUtterStrategy
{
public:
    virtual void utter() = 0;
};

class UtterNothing : public IUtterStrategy
{
public:
    void utter() override
    {
        std::cout << "I can't utter anything." << std::endl;
    }
};

// =========================================================== //

class Duck
{
private:
    std::unique_ptr<IFlyStrategy> flyStrategy;
    std::unique_ptr<IUtterStrategy> utterStrategy;

public:
    Duck(std::unique_ptr<IFlyStrategy> fs, std::unique_ptr<IUtterStrategy> us) :
        flyStrategy(std::move(fs)), utterStrategy(std::move(us))
    {
    }

    void fly()
    {
        flyStrategy->fly();
    }

    void utter()
    {
        utterStrategy->utter();
    }
};

int main()
{
    Duck duck1(
        std::make_unique<FlyNowhere>(), std::make_unique<UtterNothing>());

    duck1.fly();
    duck1.utter();
}
