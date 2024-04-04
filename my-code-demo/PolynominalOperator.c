#include <stdio.h>
#include <stdlib.h>

struct node
{
    float coef;
    int expo;
    struct node* link;
};

struct node* insert(struct node* head, float coef, int expo)
{
    struct node* new_ptr = (struct node*)malloc(sizeof(struct node));
    new_ptr->coef = coef;
    new_ptr->expo = expo;
    new_ptr->link = NULL;
    if (!head || head->expo < expo)
    {
        new_ptr->link = head;
        head = new_ptr;
        return head;
    }
    struct node* temp = head;
    while (temp->link && temp->link->expo >= expo)
    {
        temp = temp->link;
    }
    new_ptr->link = temp->link;
    temp->link = new_ptr;
    return head;
}

struct node* create()
{
    struct node* head = NULL;
    int degree;
    int i;
    int expo;
    float coef;
    printf("please enter number of terms: ");
    scanf("%d", &degree);
    for (i = 0; i < degree; i++)
    {
        printf("enter expo: ");
        scanf("%d", &expo);
        printf("enter coef: ");
        scanf("%f", &coef);
        head = insert(head, coef, expo);
    }
    return head;
}

void print(struct node* head)
{
    struct node* temp = head;
    if (!head)
    {
        printf("Zero-polynominal!");
    }
    while (temp)
    {
        printf("%.1fx^%d", temp->coef, temp->expo);
        temp = temp->link;
        if (temp) printf(" + ");
    }
    printf(".\n");
}

struct node* add_poly(struct node* head1, struct node* head2)
{
    struct node* result = NULL;
    struct node* ptr1 = head1;
    struct node* ptr2 = head2;
    struct node* ptr3;
    if (!head1) return head2;
    if (!head2) return head1;
    while (ptr1 && ptr2)
    {
        struct node* new_ptr = (struct node*)malloc(sizeof(struct node));
        new_ptr->link = NULL;
        if (ptr2->expo == ptr1->expo)
        {
            new_ptr->coef = ptr2->coef + ptr1->coef;
            new_ptr->expo = ptr1->expo;
            ptr1 = ptr1->link;
            ptr2 = ptr2->link;
        }
        else if (ptr1->expo > ptr2->expo)
        {
            new_ptr->coef = ptr1->coef;
            new_ptr->expo = ptr1->expo;
            ptr1 = ptr1->link;
        }
        else
        {
            new_ptr->coef = ptr2->coef;
            new_ptr->expo = ptr2->expo;
            ptr2 = ptr2->link;
        }
        if (result == NULL)
        {
            result = new_ptr;
            ptr3 = result;
        }
        else
        {
            ptr3->link = new_ptr;
            ptr3 = new_ptr;
        }
    }
    if (ptr1) ptr3->link = ptr1;
    else if (ptr2) ptr3->link = ptr2;
    return result;
}

struct node* multi_poly(struct node* head1, struct node* head2)
{
    struct node* ptr1 = head1;
    struct node* ptr2 = head2;
    struct node* result = NULL;
    struct node* temp = NULL;
    while (ptr1)
    {
        while (ptr2)
        {
            float coef = ptr1->coef * ptr2->coef;
            int expo = ptr1->expo + ptr2->expo;
            temp = insert(temp, coef, expo);
            ptr2 = ptr2->link;
        }
        result = add_poly(temp, result);
        temp = NULL;
        ptr1 = ptr1->link;
        ptr2 = head2;
    }
    return result;
}

int main()
{
    struct node* head1 = create();
    struct node* head2 = create();

    printf("Polynomial 1: ");
    print(head1);
    printf("Polynomial 2: ");
    print(head2);
    printf("Result: ");

    struct node* result = multi_poly(head1, head2);
    print(result);
    printf("END PROGRAM");
}
