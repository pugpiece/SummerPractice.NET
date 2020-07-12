-- добавить достижение
GO
CREATE PROCEDURE AddAchievement
 @ACHIEVEMENT_NAME NVARCHAR(50),
 @ACHIEVEMENT_DESCRIPTION NVARCHAR(50)
AS
BEGIN
 INSERT INTO Achievements([ACHIEVEMENT_NAME],[ACHIEVEMENT_DESCRIPTION]) 
 VALUES(@ACHIEVEMENT_NAME, @ACHIEVEMENT_DESCRIPTION)
 END

-- удалить достижение по индексу
GO
CREATE PROCEDURE RemoveAchievement
@ID int
AS
BEGIN
DELETE FROM User_To_Achievement
WHERE ID_ACHIEVEMENT = @ID
DELETE FROM Achievements
WHERE ID = @ID
END

-- выбрать всех достижения
GO
CREATE PROCEDURE GetAllAchievements
AS
BEGIN
SELECT ID, ACHIEVEMENT_NAME, ACHIEVEMENT_DESCRIPTION
FROM Achievements
ORDER BY ID
END

-- найти достижение по id
GO
CREATE PROCEDURE FindIdAchievement
@ID int
AS
BEGIN
	SELECT *
	FROM Achievements
	WHERE ID = @ID
END

-- найти все достижения пользователя
GO
CREATE PROCEDURE GetAllUserAchievements
@ID_USER INT
AS
BEGIN
	SELECT ACHIEVEMENT_NAME
	FROM   Achievements INNER JOIN
                  User_To_Achievement ON Achievements.ID = User_To_Achievement.ID_ACHIEVEMENT INNER JOIN
                  Users ON User_To_Achievement.ID_USER = Users.ID
	WHERE User_To_Achievement.ID_USER = @ID_USER
END

-- найти достижение по названию
GO
CREATE PROCEDURE FindNameAchievement
 @ACHIEVEMENT_NAME NVARCHAR(50)
AS
BEGIN
	SELECT *
	FROM Achievements
	WHERE ACHIEVEMENT_NAME = @ACHIEVEMENT_NAME
END
