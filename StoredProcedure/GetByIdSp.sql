CREATE PROCEDURE sp_GetEmployeeById
(
    @EmployeeId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmployeeId, EName, Age, Salary
    FROM tbl_employee
    WHERE EmployeeId = @EmployeeId;
END
GO
