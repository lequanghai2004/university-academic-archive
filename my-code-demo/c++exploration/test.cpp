void foo() {}

class Foo
{
  void f() { foo(); }
};

void f()
{
  {
    foo();
  }
}

void f() {}

int main()
{
  if (true)
  {
    foo();
  }
  else
  {
    foo();
  }

  try
  {
    foo();
  }
  catch (...)
  {
    foo();
  }

  for (int i = 0; i < 10; ++i)
  {
    foo();
  }

  while (true)
  {
    {
      /* code */
    }
  }
}