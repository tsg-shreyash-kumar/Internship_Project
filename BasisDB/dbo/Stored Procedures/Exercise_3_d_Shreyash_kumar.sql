CREATE PROCEDURE  Exercise_3_d_shreyash_kumar
@Employee_code1 nvarchar(30),
@start_date1 smalldatetime,
@end_date1  smalldatetime
AS
BEGIN
with base as(
SELECT
  MIN( (DATEDIFF(dd, @start_Date1, @end_Date1) + 1)
  -(DATEDIFF(wk, @start_date1, @end_Date1) * 2)
  -(CASE WHEN DATENAME(dw, @start_Date1) = 'Sunday' THEN 1 ELSE 0 END)
  -(CASE WHEN DATENAME(dw, @end_Date1) = 'Saturday' THEN 1 ELSE 0 END)) AS total_working_days, ea.employee_code,CONCAT(MIN(e.last_name) ,',',MIN(e.first_name)) AS full_name, SUM(ea.allocation_pt) as total_allocation_pt from Employee_Allocation1 AS ea 
  INNER JOIN employee AS e
  ON 
  ea.employee_code= e.employee_code
   
  WHERE  ea.Employee_code= @employee_code1 AND ((ea.allocation_start_date BETWEEN @start_date1  AND @end_date1)
OR   (ea.allocation_end_date BETWEEN @start_date1 AND @end_date1)
OR   (ea.allocation_start_date<@start_date1 AND  ea.allocation_end_date> @end_date1) )
GROUP BY ea.Employee_code)
Select employee_code, full_name , (total_allocation_pt/total_working_days) AS allocation_pt,
CASE
    WHEN (total_allocation_pt/total_working_days)>100 THEN 'Over-Utilization'
    WHEN (total_allocation_pt/total_working_days)<100  THEN 'Under-Utilization'
    ELSE 'Full-Utilization'
END AS Status
from base;
 END;