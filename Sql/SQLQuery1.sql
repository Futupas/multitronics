--CREATE VIEW [CommentView] AS SELECT [Comment].[AuthorName], [Comment].[Text], [Product].[WebName] FROM [dbo].[Comment], [dbo].[Product] WHERE [Comment].[ProductID]=[Product].[ID];

USE [multitronics];

--INSERT INTO [Category] ([NAME], [Description]) VALUES 
--	('����������', NULL),
--	('�����', NULL),
--	('�������', NULL);
--UPDATE [Category] SET [Name] = N'����������' WHERE [ID]=3;
--UPDATE [Category] SET [Name] = N'�����' WHERE [ID]=4;
--UPDATE [Category] SET [Name] = N'�������' WHERE [ID]=5;
--INSERT INTO [Product] ([CategoryID], [Name], [WebName], [Description], [Photo], [Price], [Count], [Specif]) VALUES 
--	(3, N'���� �����', N'white-bread', N'����� ����. ������� � �����������', N'',                 12.1, 1, N''),
--	(3, N'���� ������', N'bread-black', N'������ ����. ������ 10%, 10 ���. � �������', N'',       13.1, 3, N''),
--	(3, N'����� �������', N'makovaya-bulka', N'������ ������� �������', N'',                      13.1, 2, N''),
--	(4, N'������', N'grechka', N'��������� �����. ���� ���, ������ - �� ���������', N'',          8,    4, N''),
--	(4, N'�����', N'psheno', N'�����. �� ���� ����� ������� ����', N'',                           0.8,  9, N''),
--	(4, N'���', N'rice', N'�� ���������� ����� ����� ���, ������ �� -70% �� �����-���� 100', N'', 3,    0, N''),
--	(5, N'�������', N'sweets', N'�������� �����', N'',                                            5.6,  6, N''),
--	(5, N'����', N'cake', N'���� �� ��������, ������', N'',                                       8.1,  7, N''),
--	(5, N'���', N'honey', N'���, �������� �������', N'',                                          0,    5, N'');


  --(N'����', N'������� � ������ ����', N'white-bread'),
  --(N'����', N'������, ��� ������ �������', N'white-bread'),
  --(N'����1999', N'��� � ����� ��� ������� �����������))))) � ������, �������, �����, ��� � ��������', N'white-bread')

