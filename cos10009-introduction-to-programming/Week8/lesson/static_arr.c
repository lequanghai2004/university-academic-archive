#include <stdio.h>
#include <stdbool.h>
#include <ctype.h>

typedef struct
{
  int day;
  int month;
  int year;
} Date;

bool check_if_finished()
{
  char answer[256];
  bool result;

  printf("%s", "Do you want to enter another date? "); // output the string from the prompt "%s" defines where to place the string in the output
  scanf(" %255[^\n]%*c", answer);

  answer[0] = (char)tolower(answer[0]);

  switch (answer[0])
  {
  case 'n':
    result = true;
    break;
  case 'x':
    result = true;
    break;
  default:
    result = false;
  }

  return result;
}

Date read_date()
{
  Date d;
  char line[256];
  int result;
  char temp;

  printf("%s", "Enter Day: "); // output the string from the prompt "%s" defines where to place the string in the output
  scanf(" %255[^\n]%*c", line);
  sscanf(line, " %d %c", &d.day, &temp);

  printf("%s", "Enter Month: "); // output the string from the prompt "%s" defines where to place the string in the output
  scanf(" %255[^\n]%*c", line);
  sscanf(line, " %d %c", &d.month, &temp);

  printf("%s", "Enter Year: "); // output the string from the prompt "%s" defines where to place the string in the output
  scanf(" %255[^\n]%*c", line);
  sscanf(line, " %d %c", &d.year, &temp);

  return d;
}

int read_dates(Date dates[], int max)
{
  int index = 0;
  bool finished = false;

  while (index < max && !finished)
  {
    dates[index] = read_date();
    index++;
    if (check_if_finished())
      finished = true;
  }
  return index;
}

void print_dates(Date d[], int max)
{
  int index;

  printf("Printing all dates: \n");
  for (index = 0; index < max; index++)
  {
    printf("Day-Month-Year: %d-%d-%d\n", d[index].day, d[index].month, d[index].year);
  }
}

int main()
{
  Date dates[5];
  read_dates(dates, 5);
  print_dates(dates, 5);
}