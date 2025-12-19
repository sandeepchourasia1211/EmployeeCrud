CREATE PROCEDURE sp_UpdateEmployee
(
    @EmployeeId INT,
    @EName NVARCHAR(100),
    @Age INT,
    @Salary DECIMAL(18,2)
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tbl_employee
    SET 
        EName = @EName,
        Age = @Age,
        Salary = @Salary
    WHERE EmployeeId = @EmployeeId;
END
GO
