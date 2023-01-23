  CREATE PROCEDURE Exercise_2_a_shreyash_kumar
  @office_code1 smallint
  AS
  BEGIN
  select eo.employee_code,(e.last_name+' ,'+e.first_name) as employee_name,o.office_name, pm.title as position,gt.term as practice_affiliation,'Practice Leader' as practice_role from employee_office as eo
  join employee e
  on e.employee_code = eo.employee_code
  join practice_area_affiliation_assignment as pa
  on pa.employee_code = e.employee_code
  join gxc_classification_tags as gt
  on gt.tag_id = pa.tag_id and pa.role_code = 1
  join position_master pm
  on pm.position_no = e.position_no
  join office as o
  on o.office_code = @office_code1
  where eo.office_code = @office_code1 and eo.office_type = 4
  END;