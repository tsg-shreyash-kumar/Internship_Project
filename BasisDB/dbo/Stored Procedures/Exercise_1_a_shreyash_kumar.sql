CREATE PROCEDURE Exercise_1_a_shreyash_kumar
@employee_code1 nvarchar(50)
AS
BEGIN
Select  ep.employee_code, MIN(e.first_name) AS first_name, MIN(e.last_name) AS last_name,MIN(e.internet_address) AS email_id,MIN(pm.title) AS position_name,MIN(ep.start_date) as start_date1 ,
SUM(DATEDIFF(day, (ep.start_date), (ISNULL(ep.end_date, GETDATE()))))  AS days,
o.office_name as office_name1
from employee_position_history_clone AS ep
  INNER JOIN
office as o
ON ep.office_code=o.office_code  
INNER JOIN
employee as e
ON ep.employee_code=e.employee_code
INNER JOIN
  position_master as pm
  ON ep.position_no=pm.position_no
 WHERE ep.employee_code=@employee_code1
group by ep.position_no,ep.employee_code,o.office_name
Order by ep.employee_code,start_date1
END;