class ICommand
{
public:
    virtual void execute() = 0;
    virtual void unexecute() = 0;
};

class Command : public ICommand
{
public:
    virtual void execute() = 0;
    virtual void unexecute() = 0;
};

class Invoker
{
};

class Receiver
{
};
