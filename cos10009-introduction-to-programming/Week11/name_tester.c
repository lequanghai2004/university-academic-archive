#include <stdio.h>
#include <string.h>
#include "terminal_user_input.c"

#define LOOP_COUNT 60

void print_silly_name(my_string name)
{
  int index;
  printf("%s is a \n", name.str);
  for (index = 0; index < LOOP_COUNT; index++)
  {
    printf("silly ");
  }
  printf("name!\n");
}

int main()
{
  my_string name;
  strcpy(name.str, read_string("What is your name? ").str);
  int str_cmp1 = strcmp(name.str, "Fred");
  int str_cmp2 = strcmp(name.str, "Ted");

  if (str_cmp1 == 0 || str_cmp2 == 0)
  {
    printf("%s is an awesome name!", name.str);
  }
  else
  {
    print_silly_name(name);
  }
  return 0;
}