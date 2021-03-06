﻿
CREATE TABLE [dbo].[Agenda] (
    [AgendaId] [int] NOT NULL IDENTITY,
    [FechaEvento] [datetime],
    [ImagenPreview] [nvarchar](max),
    [ContenidoPublicacion] [nvarchar](max),
    [TituloPublicacion] [nvarchar](max),
    CONSTRAINT [PK_dbo.Agenda] PRIMARY KEY ([AgendaId])
)
CREATE TABLE [dbo].[Aplicacion] (
    [AplicacionId] [int] NOT NULL IDENTITY,
    [VersionId] [int],
    [LastModification] [datetime],
    [CreateAt] [datetime] NOT NULL,
    [CreateBy] [nvarchar](max),
    CONSTRAINT [PK_dbo.Aplicacion] PRIMARY KEY ([AplicacionId])
)
CREATE TABLE [dbo].[PantallaAplicacion] (
    [PantallaAplicacionId] [int] NOT NULL IDENTITY,
    [NroOrden] [int] NOT NULL,
    [AplicacionId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PantallaAplicacion] PRIMARY KEY ([PantallaAplicacionId])
)
CREATE INDEX [IX_AplicacionId] ON [dbo].[PantallaAplicacion]([AplicacionId])

ALTER TABLE [dbo].[PantallaAplicacion] ADD CONSTRAINT [FK_dbo.PantallaAplicacion_dbo.Aplicacion_AplicacionId] FOREIGN KEY ([AplicacionId]) REFERENCES [dbo].[Aplicacion] ([AplicacionId]) ON DELETE CASCADE
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201801120215441_InsertTablesAplicacionAgenda', N'PiPiPrestaciones.Migrations.Configuration',  0x1F8B0800000000000400D55ACD6EE33610BE17E83B083AB545D64AB29736B0779138496174F383D8BBE86DC14863872845A924E5DA28FA643DF491FA0A1D49964C91922C39BF852FB638F3CD70F80DC919F9DFBFFF197E5C85CC59829034E223F76870E83AC0FD28A07C317213357FF7A3FBF1C3B7DF0C2F8270E57C29E4DEA772A8C9E5C87D502A3EF13CE93F4048E420A4BE88643457033F0A3D1244DEF1E1E14FDED1910708E12296E30CEF12AE6808D90FFC398EB80FB14A08BB8A026072F31C47A619AA734D429031F161E4DE52FC08908AF8E80AC841AEE23AA78C1274670A6CEE3A84F348118512279F254C9588F8621AE303C266EB18506E4E9884CD244EB6E25DE773789CCEC7DB2A16507E225514F6043C7ABF099067AAEF1566B70C2086F00243ADD6E9ACB3308EDCD305F080B88E69EA64CC442AD618E341AE79E098E30725339040E9E7C019274C2502461C122508439DE49E51FF1758CFA2DF808F78C298EE263A8A639507F8E856443108B5BE8379C5F949E03A5E55DB33D54B654B339FE484ABF7C7AE738D8E907B062523B4804C5524E067E0208882E096280502177412401653CB07C3E225F80FE46289C25161F41C8166C8FC5DAA9390A0BB18E325853F0A65A431A6A5EB5C91D527E00BF53072F1ABEB5CD21504C593CD2C3E738A598C4A4A243BAD61FE29E03488F245CA56F5D98DCEA84AD8335A1C7A5BE6B7E743BCF5608F9C28B55F372F4A37F6CA8D8AF64BE5C7263896C976AD4F442A8C3D9DA3C74AA34DD7D41A0B40C95365EB5953ED0274B67E2DDEDE12AE087AFC38FEDA28AFCA63DB9D7DF85C8FF252BCBE16D18D40D95D16DB51FAF86E205D93255D645369C4749D3B6099887CA0717E6DAAE1C2575DE35244E15DC46AE3AB097E9D4689F0D1AB59D4457A46C40254B71C389532F269E676E34AEB2E57C372C103A797FF795AD74706F31C5380A6BFD1D191FB83B50A5DCD1501D0CC359B3972CD1CBAE1E7C0408173EAE7F7CD31913E096C56604C83EA134C3B1029A709C32B80C444A65CD9394AB94F63C2FA4CC600E97D64A5EE9686CD917388F12A877EF759CDA7F0A8346C0476571C879E465C7B4F4FAF5FA801A2E0B4B1FD9E9F6517B495AAD9DFB1BAD96CF172739898244C2D4C411997FF6D7E1594DB0C582436F43566DA18DAE00E9CBA84B2F0EA840C5C2DB06DE0957D4CD3E9B4F1993CE8BB8F9473AF9FB6C5B3BE1B8786DF1229AF1AAA9ADDB6E4E1B6FEF6F202BC28D4BD864A7D7845E2182F3F5AE5BE79E24CF3B27DFC6EDABF940D730CCF9735156DE96D69094F6DAC9A8CD1B4BA09E0920AA9F0A647EE497A5E8E83D0126BCEBA062617762B8965AF65C1E9423CFD5E9FE7D532BB66C7DA405CE234C374FBCBEE29FAEA3728668D14C288682C89C7114B42DE5E62B721554A5D1DAC32D01DCFA87F754463A83B667D95AB43D74B74B75053D2EAF035C336F6D03356D93A852C4A59C77C95A0DDE8DBB6DDED41E146B82E346E516EA472E5E8AED0B9F5506F46D4AA531D4E7BDC1DCBAE5975487BB407A9CB6AB642E4F2695FA4B49CB591CEAC9A27A7DAAB50B5E60C7D0ACAEE86ED40DD2E204D0B505FB4EA8BD1A5386EB3B02D4C75D4EDD3EE48FBA7DBB392C6BAC99822A5F5F24663DC5C869B5BC4EE1711D6B52217711D0CD59206E99562BA960AC2412A3098FECEC68CE27CB7025784D3391231EF98B8C78747C7C66B8CB7F34AC19332609DDE2BBC6A539FA6F1DDD9BEE9D989A9E9E30788AC8CA66197A6776D5F9F2F89400BE2BB90ACBEEF8BD8D6BB7F1470637FBE07EA3E3DF837D1FC7E161E59FDEECC4ABF5569EA7EEF4B48B31B5E87B35737FC3958B2EB747D2B2DE667618FD95536C8B3774F39C3B1FA4A131EC06AE4FE99299E38935FBFEABA074EEA8A38710E9DBF7638F1DCAD5CBDE3F1F21DD4B656CDA31BC87BB5675BAFAF2FDA84FD3FB55CED1ED123DBA8F96510F7D3FBF4CE9067C753B7586B6DBC400BB6CEEE9B6FD5DAB3DCD130DD99DDBDDABA4FD37EB58B13CC04EDBF549895922EB610E93FAB38F8951C2865267C1E15096978548818C7C71528821704722A149D135FE1B00F52666FBDBF1096A0C845780FC184DF242A4E144E19C27B56691EA429DD663FEB31577D1EDEC4D98BCAA79802BA49D33BCE0D3F4B280B4ABF2F6B4EAE068874AFD89CEBE95AAAF47C5FAC4BA4EB887704DA84AFDCE26610C60CC1E40D9F9225ECE3DB67099F6041FC7551633683EC5E886AD887E7942C0409E50663AB8F3F91C341B8FAF01F61FC22BF52280000 , N'6.1.3-40302')

