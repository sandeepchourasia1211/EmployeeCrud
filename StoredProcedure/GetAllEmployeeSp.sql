CREATE PROCEDURE sp_GetAllEmployees
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmployeeId, EName, Age, Salary
    FROM tbl_employee;
END
GO
