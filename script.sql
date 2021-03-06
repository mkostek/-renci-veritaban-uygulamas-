USE [okul]
GO
/****** Object:  Table [dbo].[ogrenci]    Script Date: 11/15/2019 23:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ogrenci](
	[ogrenci_no] [int] IDENTITY(1,1) NOT NULL,
	[ogrenci_ad] [varchar](50) NULL,
	[ogrenci_soyad] [varchar](50) NULL,
	[ogrenci_sehir] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ogrenci_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
