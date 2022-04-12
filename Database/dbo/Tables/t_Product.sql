CREATE TABLE [dbo].[t_Product](
		[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](200) NOT NULL,
	[ProductDescription] [nvarchar](2000) NOT NULL,
	[ImagePath] [nvarchar](500) NOT NULL,
	[CategoryID] [nvarchar](100) NULL,
	[ProductPrice] [decimal](18, 2) NULL,

PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]