CREATE PROCEDURE  Exercise_3_c_shreyash_kumar
@old_case_code1 nvarchar(30)
AS
BEGIN
With base as( SELECT employee_code,office_code from employee_office  GROUP BY employee_code,office_code )
,base2 as(SELECT * from employee_position_history WHERE end_date IS NULL)
, base3 as (SELECT co.client_code,co.case_code ,MIN(co.office_code) AS office_code1,MIN(o.office_name) AS case_office_name from case_office AS co INNER JOIN office as o ON   co.office_code=o.office_code GROUP BY co.client_code, co.case_code)
,base4 as(SELECT ea.employee_code, CONCAT(e.last_name ,',',e.first_name) AS full_name ,o.office_name,pm.title,ea.old_case_code,cm.case_name, c.client_name,base3.case_office_name,ea.allocation_start_date, ea.allocation_end_date,
Allocation_pt FROM Employee_Allocation1 AS ea
LEFT JOIN
employee AS e
ON ea.employee_code= e.employee_code
LEFT JOIN 
base 
ON
ea.employee_code=base.employee_code
LEFT JOIN 
office AS o
ON
base.office_code=o.office_code
LEFT JOIN 
base2
ON
base2.position_no = e.position_no
LEFT JOIN
position_master as pm
ON
base2.position_no = pm.position_no 
LEFT JOIN
Case_conversion as cc
ON
ea.old_case_code=cc.old_case_code
LEFT JOIN
case_master as cm
ON
cc.client_code= cm.client_code
AND
cc.case_code = cm.case_code
LEFT JOIN 
client as c
ON
cc.client_code=c.client_code
LEFT JOIN
base3
ON
cc.client_code= base3.client_code
AND
cc.case_code = base3.case_code)
SELECT employee_code, MIN(full_name) AS full_name,MIN(office_name) AS office_name, MIN(title) AS title,old_case_code,MIN(case_name) AS case_name , MIN(client_name) AS client_name ,MIN(case_office_name) AS case_office_name,
MIN(allocation_start_date) AS Allocation_start_date, MIN(allocation_end_date) AS Allocation_end_date, MIN(allocation_pt) as Allocation_pt
from base4 GROUP by employee_code,old_case_code HAVING old_case_code= @old_case_code1
END;
