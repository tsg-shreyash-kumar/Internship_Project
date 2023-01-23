
CREATE PROCEDURE Exercise_1_b_Shreyash_kumar
    @employee_code1 nvarchar(50),
    @position_no1  int,
    @start_date1 smalldatetime
AS

 

BEGIN

    INSERT INTO eph1 SELECT * FROM employee_position_history_clone 
    WHERE employee_code= @employee_code1
    AND   end_date IS NULL;


    UPDATE eph1
    SET  eph1.start_date= @start_date1,
    eph1.position_no = @position_no1,
    eph1.systemid = NEWID()

    SELECT * FROM eph1

 

    UPDATE employee_position_history_clone
    SET  end_date = @start_date1
    WHERE employee_code= @employee_code1
    AND   end_date IS NULL;

 

    INSERT INTO employee_position_history_clone  SELECT * FROM eph1;

 

    DELETE FROM eph1
END