-- �������� ������������
GO
CREATE PROCEDURE AddUser
 @USER_LOGIN NVARCHAR(50),
 @USER_PASSWORD INT
AS
BEGIN
	INSERT INTO Users([USER_LOGIN],[USER_PASSWORD]) 
	VALUES(@USER_LOGIN, @USER_PASSWORD)
END

-- ������� ������������ �� �������
GO
CREATE PROCEDURE RemoveUser
@ID int
AS
BEGIN
	DELETE FROM Users
	WHERE ID = @ID
END

-- ������� ���� �������������
GO
CREATE PROCEDURE GetAllUsers
AS
BEGIN
	SELECT ID, USER_LOGIN
	FROM Users
	ORDER BY ID
END

-- ���� ������������ �� ����

GO
CREATE PROCEDURE LogUser
 @USER_LOGIN NVARCHAR(50),
 @USER_PASSWORD INT
AS
BEGIN
	SELECT COUNT(*)
	FROM Users
	WHERE USER_LOGIN=@USER_LOGIN AND USER_PASSWORD=@USER_PASSWORD
END

-- ����� ������������ �� ������
GO
CREATE PROCEDURE FindLoginUser
@USER_LOGIN NVARCHAR(50)
AS
BEGIN
	SELECT ID, USER_LOGIN 
	FROM Users
	WHERE USER_LOGIN=@USER_LOGIN
END

-- ����� ������������ �� id
GO
CREATE PROCEDURE FindIdUser
@ID int
AS
BEGIN
	SELECT ID, USER_LOGIN 
	FROM Users
	WHERE ID = @ID
END