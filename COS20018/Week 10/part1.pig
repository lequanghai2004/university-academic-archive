stores = LOAD 'stores_data'
    USING PigStorage()
    AS
        store_id:chararray,
        store_name:chararray;
/*
    store_id    name
    ---         ---
    A01         Ashwood
    B01         Brookfield
    C01         Cedarville
    A02         AnotherStore
*/

salespeople = LOAD 'salespeople_data'
    USING PigStorage()
    AS
        salesperson_id:int,
        store_id:chararray,
        salesperson_name:chararray;
/*
    salesperson_id  store_id  name
    ---             ---       ---
    1               A01       Alice
    2               A01       Bob
    3               B01       Charlie
    4               C01       David
    5               C01       Eve
    6                         Frank
*/

--------------------------------------------------------------------------------

grouped = COGROUP stores BY store_id, salespeople BY store_id;
/*
    The COGROUP operation groups the 'stores' and 'salespeople' datasets by the 'store_id' field.

    Each output record contains:
        - group: the store_id,
        - stores: a bag of all store records with that store_id,
            - store_id: the unique identifier for the store,
            - store_name: the name of the store,
        - salespeople: a bag of all salesperson records with that store_id.
            - salesperson_id: the unique identifier for the salesperson,
            - store_id: the identifier for the store they are associated with,
            - salesperson_name: the name of the salesperson.
    Schema format when using LOAD with AS clause:
        (
            group:chararray,
            stores:bag{tuple(store_id:chararray, store_name:chararray)},
            salespeople:bag{tuple(salesperson_id:int, store_id:chararray, salesperson_name:chararray)}
        )
*/

DESCRIBE grouped;
/*
    grouped: {
        group: chararray,
        stores: {(store_id: chararray, store_name: chararray)},
        salespeople: {(salesperson_id: int, store_id: chararray, salesperson_name: chararray)}
    }
*/

DUMP grouped;
/*
    Output example:
        (A01,{(A01,Ashwood)},{(1,A01,Alice),(2,A01,Bob)})
        (B01,{(B01,Brookfield)},{(3,B01,Charlie)})
        (C01,{(C01,Cedarville)},{(4,C01,David),(5,C01,Eve)})
        (A02,{(A02,AnotherStore)},{})
*/

--------------------------------------------------------------------------------

joined = JOIN stores BY store_id, salespeople BY store_id; -- Inner Join
/*
    The JOIN operation combines the 'stores' and 'salespeople' datasets based on matching 'store_id' fields. 
    
    Inner join
        - only includes records with matching keys in both datasets.
        - is not specified in the JOIN clause.
    
    Left outer join
        - only includes all records from the left dataset (stores)
        - and matching records from the right dataset (salespeople).
    
    Right outer join
        - only includes all records from the right dataset (salespeople)
        - and matching records from the left dataset (stores).
    
    Full outer join
        - includes all records from both datasets
        - with NULLs for missing matches on either side.
    
    Each output record contains:
        - stores::store_id: the unique identifier for the store,
        - stores::store_name: the name of the store,
        - salespeople::salesperson_id: the unique identifier for the salesperson,
        - salespeople::store_id: the identifier for the store they are associated with,
        - salespeople::salesperson_name: the name of the salesperson.

    Schema format when using LOAD with AS clause:
        (
            stores::store_id:chararray,
            stores::store_name:chararray,
            salespeople::salesperson_id:int,
            salespeople::store_id:chararray,
            salespeople::salesperson_name:chararray
        )
*/

DESCRIBE joined;
/*
    joined: {
        stores::store_id: chararray,
        stores::store_name: chararray,
        salespeople::salesperson_id: int,
        salespeople::store_id: chararray,
        salespeople::salesperson_name: chararray
    }
*/

DUMP joined;
/*
    The store_id field appears twice in the output due to the join operation.

    Inner join output example:
        (A01,Ashwood,1,A01,Alice)
        (A01,Ashwood,2,A01,Bob)
        (B01,Brookfield,3,B01,Charlie)
        (C01,Cedarville,4,C01,David)
        (C01,Cedarville,5,C01,Eve)
        Frank is not included as there is no matching store_id in the stores.

    Left outer join output example:
        (A01,Ashwood,1,A01,Alice)
        (A01,Ashwood,2,A01,Bob)
        (B01,Brookfield,3,B01,Charlie)
        (C01,Cedarville,4,C01,David)
        (C01,Cedarville,5,C01,Eve)
        (A02,AnotherStore,,,)

    Right outer join output example:
        (A01,Ashwood,1,A01,Alice)
        (A01,Ashwood,2,A01,Bob)
        (B01,Brookfield,3,B01,Charlie)
        (C01,Cedarville,4,C01,David)
        (C01,Cedarville,5,C01,Eve)
        (,,6,,Frank)
    
    Full outer join output example:
        (A01,Ashwood,1,A01,Alice)
        (A01,Ashwood,2,A01,Bob)
        (B01,Brookfield,3,B01,Charlie)
        (C01,Cedarville,4,C01,David)
        (C01,Cedarville,5,C01,Eve)
        (A02,AnotherStore,,,)
        (,,6,,Frank)
*/

--------------------------------------------------------------------------------

joined_cleaned = FOREACH joined GENERATE
    stores::store_id AS store_id,
    stores::store_name AS store_name,
    salespeople::salesperson_id AS salesperson_id,
    salespeople::salesperson_name AS salesperson_name;

DESCRIBE joined_cleaned;
/*
    joined_cleaned: {
        store_id: chararray,
        store_name: chararray,
        salesperson_id: int,
        salesperson_name: chararray
    }
*/

DUMP joined_cleaned;
/*
    Output example:
    (A01,Ashwood,1,Alice)
    (A01,Ashwood,2,Bob)
    (B01,Brookfield,3,Charlie)
    (C01,Cedarville,4,David)
    (C01,Cedarville,5,Eve)
*/

--------------------------------------------------------------------------------

crossed = CROSS stores, salespeople;
/*
    The CROSS operation produces the Cartesian product of the 'stores' and 'salespeople' datasets.

    Each output record contains:
        - stores::store_id: the unique identifier for the store,
        - stores::store_name: the name of the store,
        - salespeople::salesperson_id: the unique identifier for the salesperson,
        - salespeople::store_id: the identifier for the store they are associated with,
        - salespeople::salesperson_name: the name of the salesperson.

    Schema format when using LOAD with AS clause:
        (
            stores::store_id:chararray,
            stores::store_name:chararray,
            salespeople::salesperson_id:int,
            salespeople::store_id:chararray,
            salespeople::salesperson_name:chararray
        )
*/

DESCRIBE crossed;
/*
    crossed: {
        stores::store_id: chararray,
        stores::store_name: chararray,
        salespeople::salesperson_id: int,
        salespeople::store_id: chararray,
        salespeople::salesperson_name: chararray
    }
*/

DUMP crossed;
/*
    Output example:
        (A01,Ashwood,1,A01,Alice)
        (A01,Ashwood,2,A01,Bob)
        (A01,Ashwood,3,B01,Charlie)
        (A01,Ashwood,4,C01,David)
        (A01,Ashwood,5,C01,Eve)
        (A01,Ashwood,6,,Frank)

        (B01,Brookfield,1,A01,Alice)
        ...
        (B01,Brookfield,6,,Frank)

        (C01,Cedarville,1,A01,Alice)
        ...
        (C01,Cedarville,6,,Frank)

        (A02,AnotherStore,1,A01,Alice)
        ...
        (A02,AnotherStore,6,,Frank)
*/

--------------------------------------------------------------------------------

/*
    COGROUP, JOIN, CROSS combine data horizontally (adding more columns).
    UNION combines data vertically (adding more rows).
*/

relation1 = LOAD 'data1' AS field1:chararray, field2:int;
relation2 = LOAD 'data2' AS field1:chararray, field2:int;

unioned = UNION relation1, relation2;
/*
    The UNION operation combines the 'relation1' and 'relation2' datasets by stacking them vertically.

    Each output record contains:
        - field1: the character array field from either relation,
        - field2: the integer field from either relation.

    Schema format when using LOAD with AS clause:
        (
            field1:chararray,
            field2:int
        )
*/

DESCRIBE unioned;
/*
    unioned: {
        field1: chararray,
        field2: int
    }
*/

DUMP unioned;
/*
    Relation1:
        (A,10)
        (B,20)
    
    Relation2:
        (C,30)
        (D,40)

    Output example:
        (A,10)
        (B,20)
        (C,30)
        (D,40)
*/

--------------------------------------------------------------------------------

customers = LOAD 'customers_data'
    USING PigStorage()
    AS
        customer_id:int,
        customer_name:chararray,
        total_purchase:double;

SPLIT customers INTO 
    golden_customers IF total_purchase > 10000,
    silver_customers IF total_purchase > 5000 AND total_purchase <= 10000;
/* 
    The SPLIT operation divides the 'relation' dataset into multiple datasets based on specified conditions.

    Each output dataset contains records from the original relation that satisfy the respective condition.

    Use cases:
        - Separating data into different categories for targeted analysis.
        - Filtering data based on specific criteria for further processing.
    
    Example:
        - Server log by date ranges
        - Customer lists by regions
        - Product lists by vendors
*/

DESCRIBE golden_customers;
/*
    golden_customers: {
        customer_id: int,
        customer_name: chararray,
        total_purchase: double
    }
*/

DESCRIBE silver_customers;
/*
    silver_customers: {
        customer_id: int,
        customer_name: chararray,
        total_purchase: double
    }
*/

DUMP golden_customers;
/*
    Output example:
        (1,John Doe,15000.0)
        (3,Jane Smith,12000.0)
*/

DUMP silver_customers;
/*
    Output example:
        (2,Emily Davis,8000.0)
        (4,Michael Brown,6000.0)
*/