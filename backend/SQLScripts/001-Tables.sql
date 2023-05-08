CREATE TABLE dbo.Recipe(
  RecipeId int IDENTITY(1,1) NOT NULL,
  Title nvarchar(100) NOT NULL,
  UserId nvarchar(150) NOT NULL,
  UserName nvarchar(150) NOT NULL,
  Created datetime2(7) NOT NULL,
  SauceName nvarchar(100) NULL,
  CrockPot bit NULL
 CONSTRAINT PK_Recipe PRIMARY KEY CLUSTERED 
(
  RecipeId ASC
)
) 
GO

CREATE TABLE dbo.Ingredient(
  IngredientId int IDENTITY(1,1) NOT NULL,
  RecipeId int NOT NULL,
  Content nvarchar(max) NOT NULL,
  SauceIngredient bit NULL
 CONSTRAINT PK_Ingredient PRIMARY KEY CLUSTERED 
(
  IngredientId ASC
)
) 
GO
ALTER TABLE dbo.Ingredient  WITH CHECK ADD  CONSTRAINT FK_Recipe_Ingredient FOREIGN KEY(RecipeId)
REFERENCES dbo.Recipe (RecipeId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Ingredient CHECK CONSTRAINT FK_Recipe_Ingredient
GO

CREATE TABLE dbo.Step(
  StepId int IDENTITY(1,1) NOT NULL,
  RecipeId int NOT NULL,
  Content nvarchar(max) NOT NULL
 CONSTRAINT PK_Step PRIMARY KEY CLUSTERED 
(
  StepId ASC
)
) 
GO
ALTER TABLE dbo.Step  WITH CHECK ADD  CONSTRAINT FK_Recipe_Step FOREIGN KEY(RecipeId)
REFERENCES dbo.Recipe (RecipeId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Step CHECK CONSTRAINT FK_Recipe_Step
GO



SET IDENTITY_INSERT dbo.Recipe ON 
GO
INSERT INTO dbo.Recipe(RecipeId, Title, UserId, UserName, Created, SauceName, CrockPot)
VALUES(1, 'Smothered Pork Chops', 
    '1',
    'erin@test.com',
    '2023-05-05 13:55',
	'Smothered',
	1)


GO
SET IDENTITY_INSERT dbo.Recipe OFF
GO

SET IDENTITY_INSERT dbo.Ingredient ON 
GO
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(1, 1, '3 lb bone-in center cut pork chops', 0)

INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(2, 1, '2 tsp Creole seasoning', 1)

INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(3, 1, '1 can Condensed Golden Mushroom Soup', 1)
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(4, 1, '½ cup beer', 1)
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(5, 1, '¼ cup flour', 1)
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(6, 1, '2 tbsp Dijon-style mustard', 1)
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(7, 1, '1 tbsp packed brown sugar', 1)
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(8, 1, '3 cups sliced mushrooms', 1)
INSERT INTO dbo.Ingredient(IngredientId, RecipeId, Content, SauceIngredient)
VALUES(9, 1, '1 cup sliced onion', 1)

GO
SET IDENTITY_INSERT dbo.Ingredient OFF 
GO

SET IDENTITY_INSERT dbo.Step ON 
GO
INSERT INTO dbo.Step(StepId, RecipeId, Content)
VALUES(1, 1, 'Season pork, if desired, then sprinkle with Creole seasoning. Stir soup, beer, flour, mustard, and born sugar in 6 qt slow cooker. Add mushrooms, onion, and pork.')

INSERT INTO dbo.Step(StepId, RecipeId, Content)
VALUES(2, 1, 'Cover and cook LOW 6 hours or until pork is done. Server over hot cooked rice.')

GO
SET IDENTITY_INSERT dbo.Step OFF 
GO