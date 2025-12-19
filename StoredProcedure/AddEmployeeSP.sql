CREATE PROCEDURE sp_AddEmployee
(
    @EName NVARCHAR(100),
    @Age INT,
    @Salary DECIMAL(18,2)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tbl_employee (EName, Age, Salary)
    VALUES (@EName, @Age, @Salary);
END
GO
