CREATE DATABASE LibraryDb
GO

USE LibraryDb
GO

-- 1 DDL

-- (02)Create the Contacts table !!! първо без релации
CREATE TABLE Contacts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(100) NULL,
    PhoneNumber NVARCHAR(20) NULL,
    PostAddress NVARCHAR(200) NULL,
    Website NVARCHAR(50) NULL
)
GO

-- (01)Create the Genres table !!! първо без релации
CREATE TABLE Genres (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL
)
GO

-- (04)Create the Authors table
CREATE TABLE Authors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
)
GO

-- (03)Create the Libraries table
CREATE TABLE Libraries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
)
GO

-- (05)Create the Books table
CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    YearPublished INT NOT NULL,
    ISBN NVARCHAR(13) UNIQUE NOT NULL,
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id)
)
GO

-- (06)Create the LibrariesBooks table (many-to-many relationship) Мапинг таблица се прави последна
-- Var 1
CREATE TABLE LibrariesBooks (
    LibraryId INT NOT NULL,
    BookId INT NOT NULL,
    PRIMARY KEY (LibraryId, BookId),
    FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
)

-- Var 2
CREATE TABLE LibrariesBooks (
    LibraryId INT FOREIGN KEY REFERENCES Libraries(Id) NOT NULL,
    BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
    PRIMARY KEY (LibraryId, BookId)
)

-- 02. Insert
-- Insert into Contacts
INSERT INTO Contacts (Email, PhoneNumber, PostAddress, Website)
VALUES 
    (NULL, NULL, NULL, NULL),
    (NULL, NULL, NULL, NULL),
    ('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
    ('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');

-- Insert into Authors
INSERT INTO Authors (Name, ContactId)
VALUES 
    ('George Orwell', 21),
    ('Aldous Huxley', 22),
    ('Stephen King', 23),
    ('Suzanne Collins', 24);

-- Insert into Books
INSERT INTO Books (Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES 
    ('1984', 1949, '9780451524935', 16, 2),
    ('Animal Farm', 1945, '9780451526342', 16, 2),
    ('Brave New World', 1932, '9780060850524', 17, 2),
    ('The Doors of Perception', 1954, '9780060850531', 17, 2),
    ('The Shining', 1977, '9780307743657', 18, 9),
    ('It', 1986, '9781501142970', 18, 9),
    ('The Hunger Games', 2008, '9780439023481', 19, 7),
    ('Catching Fire', 2009, '9780439023498', 19, 7),
    ('Mockingjay', 2010, '9780439023511', 19, 7);

-- Insert into LibrariesBooks (Many-to-Many Relationship)
INSERT INTO LibrariesBooks (LibraryId, BookId)
VALUES 
    (1, 36),
    (1, 37),
    (2, 38),
    (2, 39),
    (3, 40),
    (3, 41),
    (4, 42),
    (4, 43),
    (5, 44);


-- 03. Update
UPDATE Contacts
   SET Website = 'www.' + LOWER(REPLACE(a.Name, ' ', '')) + '.com'
  FROM Contacts c
  JOIN Authors a 
    ON c.Id = a.ContactId
 WHERE c.Website IS NULL


-- 04. Delete

-- Step 1: Delete related records from LibrariesBooks
DELETE FROM LibrariesBooks
      WHERE BookId IN 
            ( SELECT Id 
                FROM Books 
               WHERE AuthorId = ( SELECT Id 
                                    FROM Authors 
                                   WHERE [Name] = 'Alex Michaelides'))


-- Step 2: Delete related books from Books
DELETE FROM Books
      WHERE AuthorId = 
            ( SELECT Id 
                FROM Authors 
               WHERE [Name] = 'Alex Michaelides')


-- Step 3: Delete the author from Authors
DELETE FROM Authors
      WHERE [Name] = 'Alex Michaelides'


-- 05. Chronological Order

  SELECT 
         Title 
      AS [Book Title],
         ISBN,
         YearPublished 
      AS [YearReleased]
    FROM Books
ORDER BY YearPublished DESC, Title ASC


-- 06. Books by Genre

  SELECT 
         b.Id,
         b.Title,
         b.ISBN,
         g.Name
      AS Genre
    FROM Books b
    JOIN Genres g 
      ON b.GenreId = g.Id
   WHERE g.Name IN ('Biography', 'Historical Fiction')
ORDER BY g.Name ASC, b.Title ASC

-- 07. Missing Genre

  SELECT l.Name 
      AS Library,
         c.Email
    FROM Libraries l
    JOIN Contacts c 
      ON l.ContactId = c.Id
   WHERE NOT EXISTS
           (
                SELECT 1
                  FROM LibrariesBooks lb
                  JOIN Books b 
                    ON lb.BookId = b.Id
                  JOIN Genres g 
                    ON b.GenreId = g.Id
                 WHERE lb.LibraryId = l.Id
                   AND g.Name = 'Mystery'
            )
ORDER BY l.Name

-- 08. First 3 Books
  SELECT TOP 3
         [b].[Title],
         [b].[YearPublished] 
      AS [Year],
         [g].[Name]
      AS [Genre]
    FROM [Books] [b]
    JOIN [Genres] [g] 
      ON [b].[GenreId] = [g].[Id]
   WHERE 
         ([b].[YearPublished] > 2000 AND [b].[Title] LIKE '%a%')
      OR
         ([b].[YearPublished] < 1950 AND [g].[Name] LIKE '%Fantasy%')
ORDER BY [b].[Title], [b].[YearPublished] DESC

-- 09. Authors from UK

  SELECT 
         [a].[Name] 
      AS [Author],
         [c].[Email],
         [c].[PostAddress]
      AS [Address]
    FROM [Authors] [a]
    JOIN [Contacts] [c] 
      ON [a].[ContactId] = [c].[Id]
   WHERE [c].[PostAddress] LIKE '%UK%'
ORDER BY [a].[Name]


-- 10. Fictions in Denver
  SELECT 
         a.Name
      AS Author,
         b.Title,
         l.Name
      AS Library,
         c.PostAddress 
      AS LibraryAddress
    FROM Books b
    JOIN Authors a 
      ON b.AuthorId = a.Id
    JOIN Genres g 
      ON b.GenreId = g.Id
    JOIN LibrariesBooks lb 
      ON b.Id = lb.BookId
    JOIN Libraries l 
      ON lb.LibraryId = l.Id
    JOIN Contacts c 
      ON l.ContactId = c.Id
   WHERE g.Name = 'Fiction' 
     AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title

-- 11. Authors with Books

CREATE FUNCTION udf_AuthorsWithBooks (@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
   DECLARE @BookCount INT;

    -- Изчисляваме броя на книгите на зададения автор, които се намират в библиотеките
    SELECT @BookCount = COUNT(DISTINCT lb.[BookId])
      FROM [Authors] a
      JOIN [Books] b 
        ON a.[Id] = b.[AuthorId]
      JOIN [LibrariesBooks] lb 
        ON b.[Id] = lb.[BookId]
     WHERE a.[Name] = @name;

    -- Връщаме броя на книгите
    RETURN @BookCount;
END

-- 12. Search by Genre

CREATE PROCEDURE usp_SearchByGenre (@genreName NVARCHAR(100))
AS
BEGIN
    -- Избираме всички книги от зададения жанр и връщаме информацията по азбучен ред на заглавието
    SELECT 
             b.[Title],
             b.[YearPublished] 
          AS [Year],
             b.[ISBN],
             a.[Name]
          AS [Author],
             g.[Name]
          AS [Genre]
        FROM [Books] b
        JOIN [Authors] a 
          ON b.[AuthorId] = a.[Id]
        JOIN [Genres] g 
          ON b.[GenreId] = g.[Id]
       WHERE g.[Name] = @genreName
    ORDER BY b.[Title]
END


-- 13. Genre Filter
CREATE FUNCTION udf_GenreFilter (@genre NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
   SELECT b.[Id] AS [BookId],
          b.[Title] AS [BookTitle],
          b.[YearPublished],
          b.[ISBN],
          a.[Name] AS [Author],
          l.[Name] AS [Library]
     FROM [Books] b
     JOIN [Genres] g 
       ON b.[GenreId] = g.[Id]
     JOIN [LibrariesBooks] lb 
       ON b.[Id] = lb.[BookId]
     JOIN [Libraries] l 
       ON lb.[LibraryId] = l.[Id]
     JOIN [Authors] a 
       ON b.[AuthorId] = a.[Id]
    WHERE g.[Name] = @genre
)