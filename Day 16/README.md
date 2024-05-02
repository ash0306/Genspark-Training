# DAY 16

## Topics Covered

- Selection
- Projection
- Group by
- Order by
- Filtering
- Rank


## Work

### SQL Queries 

Worked with SQL Queries using the questions provided. This work can be found [here](./NorthWindPubsSQLQueries.sql)

### PostgreSQL Exercises
**Retrieve everything from a table**
```
SELECT * FROM cd.facilities;
```

**Retrieve specific columns from a table**
```
SELECT "name", membercost
FROM  cd.facilities;
```

**Control which rows are retrieved**
```
SELECT * FROM cd.facilities
WHERE membercost > 0;
```

**Control which rows are retrieved - part 2**
```
SELECT facid, "name", membercost, monthlymaintenance
FROM cd.facilities
WHERE membercost > 0 AND membercost < monthlymaintenance / 50;
```

**Basic string searches**
```
SELECT * FROM cd.facilities
WHERE "name" LIKE '%Tennis%';
```

**Matching against multiple possible values**
```
SELECT * FROM cd.facilities
WHERE facid IN (1, 5);
```

**Classify results into buckets**
```
SELECT "name", CASE
	WHEN monthlymaintenance > 100 THEN 'expensive'
	ELSE 'cheap'
  END AS "cost"
FROM
  cd.facilities;
```

**Working with dates**
```
SELECT memid, surname, firstname,  joindate
FROM  cd.members
WHERE  joindate >= '2012-09-01';
```

**Removing duplicates, and ordering results**
```
SELECT DISTINCT surname
FROM cd.members
ORDER BY surname
LIMIT 10;
```

**Combining results from multiple queries**
```
SELECT surname FROM cd.members
UNION DISTINCT
SELECT name FROM cd.facilities;
```

**Simple aggregation**
```
SELECT MAX(joindate) AS latest
FROM cd.members;
```

**More aggregation**
```
SELECT firstname, surname, joindate
FROM cd.members
WHERE joindate = (SELECT MAX(joindate) FROM cd.members);
```

**Final Completion Screenshot**

![Output](./PostgreSQLExercisesOutput.png)