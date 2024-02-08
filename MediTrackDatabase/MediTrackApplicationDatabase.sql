create database MediTracApplicationkDatabase

--patient table
CREATE TABLE PatientTable(
    patient_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    patient_name VARCHAR(255) NOT NULL,
    patient_email VARCHAR(255) NOT NULL UNIQUE,
    patient_phone BIGINT NOT NULL,
    patient_password VARCHAR(255) NOT NULL,
    patient_age INT NOT NULL
);



--admin table
CREATE TABLE AdminTable(
    admin_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    admin_name VARCHAR(255) NOT NULL,
    admin_email VARCHAR(255) NOT NULL UNIQUE,
    admin_phone BIGINT NOT NULL,
    admin_password VARCHAR(255) NOT NULL,
   
);


--medicine category table
CREATE TABLE MedicineCategoryTable (
    medicine_category_id INT PRIMARY KEY NOT NULL,
    medicine_category_name VARCHAR(50) NOT NULL
);

Drop table MedicineCategoryTable


--medicine table
CREATE TABLE MedicineTable (
    medicine_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    medicine_category_id INT NOT NULL,
    medicine_name VARCHAR(255) NOT NULL,
    brand_name VARCHAR(255) NOT NULL,
    medicine_origin VARCHAR(50) NOT NULL,
    generation VARCHAR(50) NOT NULL,
    cost DECIMAL(10, 2) NOT NULL,
	medicine_quantity INT NOT NULL,
    FOREIGN KEY (medicine_category_id) REFERENCES MedicineCategoryTable(medicine_category_id) ON DELETE CASCADE
);

DROP TABLE MedicineTable

--medicine cart table
CREATE TABLE MedicineCartTable (
    medicine_cart_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    medicine_id INT,
    patient_id INT,
    quantity INT NOT NULL,
    total_price DECIMAL(10, 2),
    FOREIGN KEY (medicine_id) REFERENCES MedicineTable(medicine_id) ON DELETE CASCADE,
    FOREIGN KEY (patient_id) REFERENCES PatientTable(patient_id) ON DELETE CASCADE
);

drop table MedicineCartTable



--ratings table

CREATE TABLE RatingTable (
    rating_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    medicine_id INT,
    patient_id INT,
    rating DECIMAL(3, 2),
	average_rating DECIMAL(3, 2) NULL,
    feedback TEXT,
    FOREIGN KEY (medicine_id) REFERENCES MedicineTable(medicine_id) ON DELETE CASCADE,
    FOREIGN KEY (patient_id) REFERENCES PatientTable(patient_id) ON DELETE CASCADE
);


drop table  RatingTable








--Inserting Patient
INSERT INTO PatientTable (patient_name, patient_email, patient_phone, patient_password, patient_age)
VALUES 
('John Doe', 'john@gmail.com', 1234567890, 'Pass@123', 30),
('Jane Smith', 'jane.smith@example.com', 9876543210, 'securepass', 20),
('Bob Johnson', 'bob.johnson@example.com', 5551112233, 'bobpass', 45),
('Alice White', 'alice.white@example.com', 4442221111, 'alicepass', 35),
('Charlie Brown', 'charlie.brown@example.com', 9998887777, 'charliepass', 28),
('Eva Davis', 'eva.davis@example.com', 7773331111, 'evapass', 40),
('Michael Lee', 'michael.lee@example.com', 1112223333, 'mikepass', 32),
('Olivia Miller', 'olivia.miller@example.com', 6665554444, 'oliviapass', 29),
('David Taylor', 'david.taylor@example.com', 2224446666, 'davidpass', 38),
('Sophie Hall', 'sophie.hall@example.com', 8889990000, 'sophiepass', 42);


-- Inserting data into MedicineCategoryTable
INSERT INTO MedicineCategoryTable (medicine_category_id, medicine_category_name)
VALUES
(1, 'Homeopathic'),
(2, 'Ayurveda'),
(3, 'Allopathic');



-- Inserting data into MedicineTable with age groups
INSERT INTO MedicineTable (medicine_category_id, medicine_name, brand_name, medicine_origin, generation, cost, medicine_quantity)
VALUES
--medicine data
-- Homeopathic Medicines
(1, 'Arnica', 'Boiron', 'France', 'Adult', 1574.25,10),
(1, 'Rhus Tox', 'Hyland''s', 'USA', 'Teenagers', 1162.50,10),
(1, 'Calendula', 'Weleda', 'Switzerland', 'Kids', 956.25,10),
(1, 'Silicea', 'Hahnemann', 'Germany', 'Elders', 674.25,10),
(1, 'Belladonna', 'Boiron', 'France', 'Adult', 1424.25,10),
(1, 'Chamomilla', 'Hyland''s', 'USA', 'Teenagers', 1068.75,10),
(1, 'Calcarea Phos', 'WHP', 'USA', 'Kids', 806.25,10),
(1, 'Lycopodium', 'Hapco', 'Germany', 'Elders', 749.25,10),

-- Ayurvedic Medicines
(2, 'Ashwagandha', 'Himalaya', 'India', 'Adult', 956.25,10),
(2, 'Triphala', 'Dabur', 'India', 'Teenagers', 674.25,10),
(2, 'Chyawanprash', 'Patanjali', 'India', 'Kids', 768.75,10),
(2, 'Shilajit', 'Zandu', 'India', 'Elders', 1087.50,10),
(2, 'Neem Capsules', 'Organic India', 'India', 'Adult', 1181.25,10),
(2, 'Brahmi Ghrita', 'Sri Sri Tattva', 'India', 'Teenagers', 899.25,10),
(2, 'Pippali Rasayana', 'Dhootapapeshwar', 'India', 'Kids', 993.75,10),
(2, 'Mahanarayan Oil', 'Baidyanath', 'India', 'Elders', 1312.50,10),

-- Allopathic Medicines
(3, 'Aspirin', 'Bayer', 'Germany', 'Adult', 411.75,10),
(3, 'Ibuprofen', 'Advil', 'USA', 'Teenagers', 543.75,10),
(3, 'Children''s Tylenol', 'Johnson & Johnson', 'USA', 'Kids', 674.25,10),
(3, 'Arthritis Relief', 'Aleve', 'USA', 'Elders', 937.50,10),
(3, 'Paracetamol', 'Tylenol', 'USA', 'Adult', 374.25,10),
(3, 'Omeprazole', 'Prilosec', 'USA', 'Teenagers', 693.75,10),
(3, 'Children''s Motrin', 'Motrin', 'USA', 'Kids', 599.25,10),
(3, 'Blood Pressure Control', 'Norvasc', 'USA', 'Elders', 1687.50,10)




--genaralQueries

drop table PatientTable

select * from PatientTable

delete from PatientTable;

DBCC CHECKIDENT (PatientTable, RESEED, 1);

truncate table PatientTable;

drop table MedicineCartTable

select * from AdminTable

select * from PatientTable

select * from RatingTable

drop table RatingTable

select * from AdminTable

select * from PatientTable

select * from MedicineTable





-------------------------------ADMIN


alter PROCEDURE GetMedicinesProcedure
AS
BEGIN
    
SELECT medicine_id, medicine_name, medicine_category_name, brand_name, medicine_origin, generation,cost,medicine_quantity
FROM MedicineTable M
INNER JOIN 
MedicineCategoryTable C 
ON
M.medicine_category_id = C.medicine_category_id

END






CREATE PROCEDURE UpdateMedicine
    @MedicineId INT,
    @MedicineName VARCHAR(255) = NULL,
    @BrandName VARCHAR(255) = NULL,
    @Origin VARCHAR(50) = NULL,
    @Generation VARCHAR(50) = NULL,
    @Cost DECIMAL(10, 2) = NULL,
    @CategoryId INT = NULL,
	@MedicineQuantity INT = NULL
AS
BEGIN
    UPDATE MedicineTable 
    SET 
        medicine_name = ISNULL(@MedicineName, medicine_name),
        brand_name = ISNULL(@BrandName, brand_name),
        medicine_origin = ISNULL(@Origin, medicine_origin),
        generation = ISNULL(@Generation, generation),
        cost = ISNULL(@Cost, cost),
		medicine_quantity = ISNULL(@MedicineQuantity, medicine_quantity),
        medicine_category_id = ISNULL(@CategoryId, medicine_category_id)
    WHERE medicine_id = @MedicineId;
END







--add new medicine procedure
	CREATE PROCEDURE AddNewMedicine
    @MedicineName VARCHAR(255),
    @BrandName VARCHAR(255),
    @Origin VARCHAR(50),
    @Generation VARCHAR(50),
    @Cost DECIMAL(10, 2),
	@MedicineQuantity INT,
    @CategoryId INT
AS
BEGIN
    -- Your insert logic here for adding a new medicine
    INSERT INTO MedicineTable (medicine_category_id, medicine_name, brand_name, medicine_origin, generation, cost,medicine_quantity)
    VALUES (@CategoryId, @MedicineName, @BrandName, @Origin, @Generation, @Cost,@MedicineQuantity);
END






CREATE PROCEDURE DeleteMedicineProcedure
    @MedicineId INT
AS
BEGIN
    BEGIN TRY
      
        BEGIN TRANSACTION;

        DELETE FROM dbo.MedicineTable WHERE medicine_id = @MedicineId;
        COMMIT;
    END TRY
    BEGIN CATCH
        -- An error occurred, rollback the transaction
        ROLLBACK;
    END CATCH;
END;







CREATE PROCEDURE GetPatientsDetailsProcedure
AS
BEGIN
    SELECT * FROM PatientTable;
END


exec GetPatientsDetailsProcedure







CREATE PROCEDURE DeletePatientProcedure
    @PatientId INT
AS
BEGIN
 DELETE FROM PatientTable WHERE patient_id = @PatientId;
END




CREATE PROCEDURE GetMedicineCategoryProcedure
AS
BEGIN
    SELECT * FROM MedicineCategoryTable;
END

exec GetMedicineCategoryProcedure






------------------------------------------------------- search 

-- search functionalities procedrues
Create PROCEDURE SearchProcMedicine
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT medicine_id, medicine_name, medicine_origin,brand_name,medicine_category_name,generation,cost,medicine_quantity
    FROM MedicineTable M
	INNER JOIN MedicineCategoryTable C ON M.medicine_category_id = C.medicine_category_id
    WHERE medicine_name LIKE '%' + @SearchTerm + '%' OR 
		  brand_name LIKE '%' + @SearchTerm + '%' OR 
		  generation LIKE '%' + @SearchTerm + '%' OR 
		  medicine_category_name LIKE '%' + @SearchTerm + '%' OR
		  medicine_origin LIKE '%' + @SearchTerm + '%';
END;



CREATE PROCEDURE SearchByMedName
	@SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT medicine_id, medicine_name, medicine_origin,brand_name,medicine_category_name,generation,cost,medicine_quantity
    FROM MedicineTable M
	INNER JOIN MedicineCategoryTable C ON M.medicine_category_id = C.medicine_category_id
    WHERE medicine_name LIKE '%' + @SearchTerm + '%';
END;




CREATE PROCEDURE SearchByBrandName
	@SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT medicine_id, medicine_name, medicine_origin,brand_name,medicine_category_name,generation,cost,medicine_quantity
    FROM MedicineTable M
	INNER JOIN MedicineCategoryTable C ON M.medicine_category_id = C.medicine_category_id
    WHERE brand_name LIKE '%' + @SearchTerm + '%';
END;




CREATE PROCEDURE SearchByGeneration
	@SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT medicine_id, medicine_name, medicine_origin,brand_name,medicine_category_name,generation,cost,medicine_quantity
    FROM MedicineTable M
	INNER JOIN MedicineCategoryTable C ON M.medicine_category_id = C.medicine_category_id
    WHERE generation LIKE '%' + @SearchTerm + '%';
END;



CREATE PROCEDURE SearchByMedCategory
	@SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT medicine_id, medicine_name, medicine_origin,brand_name,medicine_category_name,generation,cost,medicine_quantity
    FROM MedicineTable M
	INNER JOIN MedicineCategoryTable C ON M.medicine_category_id = C.medicine_category_id
    WHERE medicine_category_name LIKE '%' + @SearchTerm + '%';
END;



CREATE PROCEDURE SearchByMedOrigin
	@SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT medicine_id, medicine_name, medicine_origin,brand_name,medicine_category_name,generation,cost,medicine_quantity
    FROM MedicineTable M
	INNER JOIN MedicineCategoryTable C ON M.medicine_category_id = C.medicine_category_id
    WHERE medicine_origin LIKE '%' + @SearchTerm + '%';
END;








--------------------------------------------------------------- Login Registration

-- Stored Procedure for Patient Registration
create PROCEDURE RegisterPatientProc
    @name NVARCHAR(50),
	@email Nvarchar(50),
	@phone bigint,
    @Password NVARCHAR(50),
	@age int
AS
BEGIN
    INSERT INTO PatientTable (patient_name, patient_email, patient_phone, patient_password, patient_age) VALUES (@name, @email,@phone,@Password,@age);
END;



-- Stored Procedure for Patient Login
CREATE PROCEDURE ValidateLoginProc
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = (SELECT COUNT(*) FROM PatientTable WHERE patient_email = @Username AND patient_password = @Password);
END;


-- Stored Procedure for Getting Patient ID
CREATE PROCEDURE GetPatientIdProc
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT patient_id, patient_name
    FROM PatientTable
    WHERE patient_email = @Username AND patient_password = @Password;
END;

-------------------------ADMIN-----------------------
-- Stored Procedure for Admin Registration
create PROCEDURE RegisterAdminProc
    @name NVARCHAR(50),
	@email Nvarchar(50),
	@phone bigint,
    @Password NVARCHAR(50)
	
AS
BEGIN
    INSERT INTO AdminTable (admin_name, admin_email, admin_phone, admin_password) VALUES (@name, @email,@phone,@Password);
END;

-- Stored Procedure for Admin Login
CREATE PROCEDURE ValidateAdminProc
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = (SELECT COUNT(*) FROM AdminTable WHERE admin_email = @Username AND admin_password = @Password);
END;


-- Stored Procedure for Getting Admin ID
CREATE PROCEDURE GetAdminIdProc
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT admin_id,admin_name
    FROM AdminTable
    WHERE admin_email = @Username AND admin_password = @Password;
END;















-----------------------------------------Rating

-- stored procedure for Ratings Table


CREATE PROCEDURE DeleteRatings
    @rating_id INT
AS
BEGIN
    -- Delete the rating based on the provided rating_id
    DELETE FROM RatingTable
    WHERE rating_id = @rating_id;
END;



CREATE PROCEDURE GetAllRatings
AS
BEGIN
    SELECT * FROM RatingTable;
END;






CREATE PROCEDURE GetAllRatingProcedure
AS
BEGIN
  SELECT r.rating_id,
         r.medicine_id,
         m.medicine_name,
         r.patient_id,
         p.patient_name,
         r.rating,
         r.average_rating,
         r.feedback
  FROM RatingTable r
  INNER JOIN MedicineTable m ON r.medicine_id = m.medicine_id
  INNER JOIN PatientTable p ON r.patient_id = p.patient_id;
END

select * from PatientTable
-------------------------------------------------------

alter PROCEDURE GetMedicinesProcedure
AS
BEGIN
    
SELECT medicine_id, medicine_name, medicine_category_name, brand_name, medicine_origin, generation,cost 
FROM MedicineTable M
INNER JOIN 
MedicineCategoryTable C 
ON
M.medicine_category_id = C.medicine_category_id

END







CREATE PROCEDURE GetMedicineRatingInfo
    @medicine_id INT
AS
BEGIN
    SELECT
        MT.medicine_id,
        MT.medicine_name,
        MT.generation,
        MT.cost,
		RT.rating_id,
        PT.patient_name,
        RT.average_rating,
        RT.feedback
    FROM
        MedicineTable MT
    JOIN
        RatingTable RT ON MT.medicine_id = RT.medicine_id
    JOIN
        PatientTable PT ON RT.patient_id = PT.patient_id
    WHERE
        MT.medicine_id = @medicine_id;
END;



CREATE PROCEDURE GiveRating
    @medicine_id INT,
    @patient_id INT,
    @rating DECIMAL(3, 2),
    @feedback TEXT
AS
BEGIN
    INSERT INTO RatingTable (medicine_id, patient_id, rating, feedback)
    VALUES (@medicine_id, @patient_id, @rating, @feedback);

 
    UPDATE RatingTable
    SET average_rating = (
            SELECT AVG(rating)
            FROM RatingTable
            WHERE medicine_id = @medicine_id
        )
    WHERE medicine_id = @medicine_id;
END;




CREATE PROCEDURE GiveRatingAndUpdateAverage
    @rating_id INT,
    @patient_id INT,
    @rating DECIMAL(3, 2),
    @feedback TEXT
AS
BEGIN
	DECLARE @medicine_id INT;

    -- Get the medicine_id corresponding to the provided rating_id and patient_id
    SELECT @medicine_id = medicine_id
    FROM RatingTable
    WHERE rating_id = @rating_id AND patient_id = @patient_id;

	UPDATE RatingTable SET 
	rating = @rating,
	feedback = @feedback
	where rating_id=@rating_id AND patient_id=@patient_id;
  
    UPDATE RatingTable
    SET average_rating = (
            SELECT AVG(rating)
            FROM RatingTable
            WHERE medicine_id = @medicine_id
        )
    WHERE medicine_id = @medicine_id;
END;



CREATE PROCEDURE SearchInRatings
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    -- Selecting specific columns from MedicineTable and joining with RatingTable
    SELECT 
        M.medicine_id, 
        M.medicine_name, 
        M.generation,
        M.cost,
		RT.rating_id,
        RT.average_rating,
        RT.feedback
    FROM 
        MedicineTable M
    INNER JOIN 
        RatingTable RT ON M.medicine_id = RT.medicine_id
    -- Filtering based on the search term
    WHERE
        M.medicine_name LIKE '%' + @SearchTerm + '%' OR 
        M.generation LIKE '%' + @SearchTerm + '%' OR 
        RT.feedback LIKE '%' + @SearchTerm + '%'
		
END;






CREATE PROCEDURE UpdateMedicineRatingAndFeedback
    @medicine_id INT,
    @newRating DECIMAL(3, 2),
    @newFeedback TEXT
AS
BEGIN
    -- Update individual rating and feedback
    UPDATE RatingTable
    SET
        rating = @newRating,
        feedback = @newFeedback
    WHERE
        medicine_id = @medicine_id;

    -- Recalculate average rating
    UPDATE RatingTable
    SET
        average_rating = (
            SELECT AVG(rating)
            FROM RatingTable
            WHERE medicine_id = @medicine_id
        )
    WHERE
        medicine_id = @medicine_id;
END;

select * from MedicineTable

select * from PatientTable;

select * from AdminTable



CREATE PROCEDURE forgPasswordProc
    @forgEmail NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = (SELECT COUNT(*) FROM patientTable WHERE patient_email = @forgEmail);
END;

CREATE PROCEDURE changePasswordProc
    @forgEmail NVARCHAR(50),
	@forgPassword NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
	Update PatientTable set patient_password=@forgPassword where patient_email=@forgEmail
    SET @Result = (SELECT COUNT(*) FROM patientTable WHERE patient_email = @forgEmail);
END;







-------------------sana procedure

CREATE PROCEDURE AddToCartProc
    @PatientId INT,
    @MedicineId INT,
    @Quantity INT
AS
BEGIN
    -- Check if quantity is negative
    IF @Quantity < 0
    BEGIN
        RAISERROR('Quantity cannot be negative.', 16, 1);
        RETURN;
    END

    -- Check if there is enough stock
    IF @Quantity > (SELECT medicine_quantity FROM MedicineTable WHERE medicine_id = @MedicineId)
    BEGIN
        RAISERROR('Not enough stock.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM MedicineCartTable WHERE medicine_id = @MedicineId AND patient_id = @PatientId)
    BEGIN
        -- Product already exists in the cart, update the quantity and total_price
        UPDATE MedicineCartTable
        SET
            quantity = quantity + @Quantity,
            total_price = (quantity + @Quantity) * (SELECT cost FROM MedicineTable WHERE medicine_id = @MedicineId)
        WHERE medicine_id = @MedicineId AND patient_id = @PatientId;
    END
    ELSE
    BEGIN
        -- Product does not exist in the cart, insert a new record
        INSERT INTO MedicineCartTable (medicine_id, patient_id, quantity, total_price)
        VALUES (
            @MedicineId,
            @PatientId,
            @Quantity,
            @Quantity * (SELECT cost FROM MedicineTable WHERE medicine_id = @MedicineId)
        );
    END;
END;





Create PROCEDURE GetCartItemsProc
    @PatientId INT
AS
BEGIN
    SELECT
        MCT.medicine_cart_id,
        MCT.medicine_id,
        MT.medicine_name,
        MT.brand_name,
		MT.medicine_origin,
		MT.generation,
		MCategory.medicine_category_name,
		mt.cost,
        MCT.quantity,
        MCT.total_price
    FROM MedicineCartTable MCT
    INNER JOIN MedicineTable MT ON MCT.medicine_id = MT.medicine_id
	INNER JOIN MedicineCategoryTable MCategory ON MT.medicine_category_id = MCategory.medicine_category_id
    WHERE MCT.patient_id = @PatientId;
END









			-- Removing the Cart Item 
CREATE PROCEDURE RemoveFromCartProc
    @Patient_id INT,
    @Medicine_id INT
AS
BEGIN
 
    DELETE FROM MedicineCartTable
    WHERE patient_id = @Patient_id AND medicine_id = @Medicine_id;

    -- Return the number of rows affected by the delete operation
    SELECT @@ROWCOUNT AS 'RowsAffected';
END;







--clear cart proc
CREATE PROCEDURE ClearCartProc
    @Patient_id INT
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @Medicine_id INT;
    DECLARE @Quantity INT;

    DECLARE cart_cursor CURSOR FOR
    SELECT medicine_id, quantity
    FROM MedicineCartTable
    WHERE patient_id = @Patient_id;

    OPEN cart_cursor;
    FETCH NEXT FROM cart_cursor INTO @Medicine_id, @Quantity;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Update medicine_quantity in MedicineTable
        UPDATE MedicineTable
        SET medicine_quantity = medicine_quantity - @Quantity
        WHERE medicine_id = @Medicine_id;

        FETCH NEXT FROM cart_cursor INTO @Medicine_id, @Quantity;
    END;

    CLOSE cart_cursor;
    DEALLOCATE cart_cursor;

    -- Delete records from MedicineCartTable
    DELETE FROM MedicineCartTable
    WHERE patient_id = @Patient_id;

    COMMIT TRANSACTION;
END;



create PROCEDURE ValidatePasswordSP
    @Patient_Id int ,
    @Password NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = (SELECT COUNT(*) FROM PatientTable WHERE patient_id = @Patient_Id AND patient_password = @Password);
END;




    @PatientId INT,
    @MedicineId INT,
    @Quantity INT
AS
BEGIN
    -- Check if quantity is negative
    IF @Quantity < 0
    BEGIN
        RAISERROR('Quantity cannot be negative.', 16, 1);
        RETURN;
    END

    -- Check if there is enough stock
    IF @Quantity > (SELECT medicine_quantity FROM MedicineTable WHERE medicine_id = @MedicineId)
    BEGIN
        RAISERROR('Not enough stock.', 16, 1);
        RETURN;
    END

    









CREATE PROCEDURE UpdateCartQuantityByReducingQuantity
    @PatientId INT,
    @MedicineId INT,
    @UpdateQuantity INT
AS
BEGIN
    DECLARE @CurrentQuantity INT, @Cost DECIMAL(10, 2), @AvailableQuantity INT;

    -- Fetch current quantity and cost per unit
    SELECT @CurrentQuantity = quantity, @Cost = cost
    FROM MedicineCartTable MCT
    INNER JOIN MedicineTable MT ON MCT.medicine_id = MT.medicine_id
    WHERE MCT.patient_id = @PatientId AND MCT.medicine_id = @MedicineId;

    -- Check available quantity
    SELECT @AvailableQuantity = quantity
    FROM MedicineCartTable
    WHERE medicine_id = @MedicineId;

    -- If the user wants to subtract and the available quantity is less than the update quantity, don't allow subtraction
    IF @UpdateQuantity < 0 AND @AvailableQuantity < ABS(@UpdateQuantity)
    BEGIN
        PRINT 'Invalid operation The Quantity to substract cannot be more than the actual available quantity.';
        RETURN; -- Exit the procedure
    END;

    -- Calculate new quantity and total_price based on user input
    DECLARE @NewQuantity INT, @NewTotalPrice DECIMAL(10, 2);

    SET @NewQuantity = @CurrentQuantity + @UpdateQuantity;

    -- Update MedicineCartTable with new quantity and total_price
    UPDATE MedicineCartTable
    SET
        quantity = @NewQuantity,
        total_price = @NewQuantity * @Cost
    WHERE patient_id = @PatientId AND medicine_id = @MedicineId;

    PRINT 'Quantity updated successfully.';
END;

drop proc UpdateCartQuantity


CREATE PROCEDURE UpdateCartQuantityByAddingQuantity
    @PatientId INT,
    @MedicineId INT,
    @UpdateQuantity INT
AS
BEGIN
    DECLARE @CurrentQuantity INT, 
            @Cost DECIMAL(10, 2), 
            @AvailableQuantity INT;

    -- Fetch current quantity and cost per unit
    SELECT @CurrentQuantity = quantity, @Cost = cost
    FROM MedicineCartTable MCT
    INNER JOIN MedicineTable MT ON MCT.medicine_id = MT.medicine_id
    WHERE MCT.patient_id = @PatientId AND MCT.medicine_id = @MedicineId;

    -- Check available quantity
    SELECT @AvailableQuantity = medicine_quantity
    FROM MedicineTable
    WHERE medicine_id = @MedicineId;

    -- Calculate new quantity
    DECLARE @NewQuantity INT;
    SET @NewQuantity = @CurrentQuantity + @UpdateQuantity;

    -- If the new quantity is greater than available stock, return message
    IF @NewQuantity > @AvailableQuantity
    BEGIN
        PRINT 'Not enough stock.';
        RETURN; -- Exit the procedure
    END;

    -- Update MedicineCartTable with new quantity and total_price
    UPDATE MedicineCartTable
    SET
        quantity = @NewQuantity,
        total_price = @NewQuantity * @Cost
    WHERE patient_id = @PatientId AND medicine_id = @MedicineId;

    PRINT 'Quantity updated successfully.';
END;






CREATE PROCEDURE UpdateReplaceCartQuantity
    @PatientId INT,
    @MedicineId INT,
    @UpdateQuantity INT
AS
BEGIN
    DECLARE @CurrentQuantity INT, @Cost DECIMAL(10, 2), @AvailableQuantity INT;

    -- Fetch current quantity and cost per unit
    SELECT @CurrentQuantity = quantity, @Cost = cost
    FROM MedicineCartTable MCT
    INNER JOIN MedicineTable MT ON MCT.medicine_id = MT.medicine_id
    WHERE MCT.patient_id = @PatientId AND MCT.medicine_id = @MedicineId;

    -- Check if @UpdateQuantity is negative
    IF @UpdateQuantity < 0
    BEGIN
        PRINT 'Quantity cannot be negative.';
        RETURN; -- Exit the procedure
    END;

    -- Check available quantity in MedicineTable
    SELECT @AvailableQuantity = medicine_quantity
    FROM MedicineTable
    WHERE medicine_id = @MedicineId;

    -- If the user wants to replace and the available quantity is less than the update quantity, don't allow replacement
    IF @UpdateQuantity > @AvailableQuantity
    BEGIN
        PRINT 'Not enough stock.';
        RETURN; -- Exit the procedure
    END;

    -- Update MedicineCartTable with new quantity and total_price
    UPDATE MedicineCartTable
    SET
        quantity = @UpdateQuantity,
        total_price = @UpdateQuantity * @Cost
    WHERE patient_id = @PatientId AND medicine_id = @MedicineId;

    PRINT 'Quantity updated successfully.';
END;












CREATE PROCEDURE CheckMedicineExistsForPatient
    @PatientId INT,
    @MedicineId INT,
    @Exists BIT OUTPUT
AS
BEGIN
    SELECT @Exists = COUNT(*)
    FROM MedicineCartTable
    WHERE patient_id = @PatientId AND medicine_id = @MedicineId;
END;







select * from PatientTable;

select * from AdminTable;

insert into AdminTable values('Sanchit Kothekar','admin@cybage.com',9988772211,'Admin@1234')



alter PROCEDURE forgPasswordProc
    @forgEmail NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = (SELECT COUNT(*) FROM patientTable WHERE patient_email = @forgEmail);
END;

alter PROCEDURE changePasswordProc
    @forgEmail NVARCHAR(50),
	@forgPassword NVARCHAR(50),
    @Result INT OUTPUT
AS
BEGIN
	Update PatientTable set patient_password=@forgPassword where patient_email=@forgEmail
    SET @Result = (SELECT COUNT(*) FROM patientTable WHERE patient_email = @forgEmail);
END;