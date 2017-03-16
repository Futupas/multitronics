--CREATE VIEW [CommentView] AS SELECT [Comment].[AuthorName], [Comment].[Text], [Product].[WebName] FROM [dbo].[Comment], [dbo].[Product] WHERE [Comment].[ProductID]=[Product].[ID];

USE [multitronics];

--INSERT INTO [Category] ([NAME], [Description]) VALUES 
--	('Хлебобулки', NULL),
--	('Крупы', NULL),
--	('Сладкое', NULL);
--UPDATE [Category] SET [Name] = N'Хлебобулки' WHERE [ID]=3;
--UPDATE [Category] SET [Name] = N'Крупы' WHERE [ID]=4;
--UPDATE [Category] SET [Name] = N'Сладкое' WHERE [ID]=5;
--INSERT INTO [Product] ([CategoryID], [Name], [WebName], [Description], [Photo], [Price], [Count], [Specif]) VALUES 
--	(3, N'Хлеб белый', N'white-bread', N'Белый хлеб. Вкусный и стандартный', N'',                 12.1, 1, N''),
--	(3, N'Хлеб черный', N'bread-black', N'Черный хлеб. Скидка 10%, 10 коп. в подарок', N'',       13.1, 3, N''),
--	(3, N'Булка маковая', N'makovaya-bulka', N'Просто маковая булочка', N'',                      13.1, 2, N''),
--	(4, N'Гречка', N'grechka', N'Гречневая крупа. Норм так, купите - не пожалеете', N'',          8,    4, N''),
--	(4, N'Пшено', N'psheno', N'Пшено. Из него можно сделать кашу', N'',                           0.8,  9, N''),
--	(4, N'Рис', N'rice', N'Не пропустите супер новый рис, скидка до -70% по промо-коду 100', N'', 3,    0, N''),
--	(5, N'Конфеты', N'sweets', N'Конфетки супер', N'',                                            5.6,  6, N''),
--	(5, N'Торт', N'cake', N'Торт из Торторва, Италия', N'',                                       8.1,  7, N''),
--	(5, N'Мед', N'honey', N'Мед, сделаный пчелами', N'',                                          0,    5, N'');


  --(N'Петя', N'Вкусный и свежий хлеб', N'white-bread'),
  --(N'Вася', N'Плохой, мне чесвый попался', N'white-bread'),
  --(N'Дима1999', N'Мне в новый год продали прошлогоний))))) Я шутник, канешно, ващее, ору в голосину', N'white-bread')

