#include <iostream>
#include <memory>

class Pizza
{
public:
    virtual ~Pizza() {}
    virtual std::string getDescription() const = 0;
    virtual double getCost() const = 0;
};

class PlainPizza : public Pizza
{
public:
    std::string getDescription() const override
    {
        return "Plain Pizza";
    }

    double getCost() const override
    {
        return 4.0;
    }
};

class PizzaDecorator : public Pizza
{
protected:
    std::unique_ptr<Pizza> pizza;

public:
    PizzaDecorator(std::unique_ptr<Pizza> pizza) : pizza(std::move(pizza)) {}

    std::string getDescription() const override
    {
        return pizza->getDescription();
    }

    double getCost() const override
    {
        return pizza->getCost();
    }
};

class CheeseDecorator : public PizzaDecorator
{
public:
    CheeseDecorator(std::unique_ptr<Pizza> pizza) :
        PizzaDecorator(std::move(pizza))
    {
    }

    std::string getDescription() const override
    {
        return pizza->getDescription() + ", Cheese";
    }

    double getCost() const override
    {
        return pizza->getCost() + 1.0;
    }
};

class HamDecorator : public PizzaDecorator
{
public:
    HamDecorator(std::unique_ptr<Pizza> pizza) :
        PizzaDecorator(std::move(pizza))
    {
    }

    std::string getDescription() const override
    {
        return pizza->getDescription() + ", Ham";
    }

    double getCost() const override
    {
        return pizza->getCost() + 2.0;
    }
};

int main()
{
    std::unique_ptr<Pizza> pizza = std::make_unique<HamDecorator>(
        std::make_unique<CheeseDecorator>(std::make_unique<PlainPizza>()));

    std::cout << "Description: " << pizza->getDescription() << std::endl;
    std::cout << "Cost: $" << pizza->getCost() << std::endl;

    return 0;
}
