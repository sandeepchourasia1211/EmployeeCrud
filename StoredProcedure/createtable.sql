use OrgEmpInterview

CREATE TABLE tbl_employee
(
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EName NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    Salary DECIMAL(18,2) NOT NULL
);
