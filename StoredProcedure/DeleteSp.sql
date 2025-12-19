CREATE PROCEDURE sp_DeleteEmployee
(
    @EmployeeId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM tbl_employee
    WHERE EmployeeId = @EmployeeId;
END
GO
