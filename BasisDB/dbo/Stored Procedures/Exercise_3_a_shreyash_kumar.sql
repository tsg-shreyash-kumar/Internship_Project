CREATE Procedure  Exercise_3_a_shreyash_kumar
@employee_code1 nvarchar(30),
@old_case_code1 nvarchar(30),
@allocation_start_date1 smalldatetime,
@allocation_end_date1 smalldatetime,
@allocation_pt1 INT
AS
BEGIN
INSERT INTO Employee_Allocation1 VALUES(@employee_code1,@old_case_code1,@allocation_start_date1,@allocation_end_date1,@allocation_pt1)
END;