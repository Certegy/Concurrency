CREATE TABLE [dbo].[ZZ_UNIT_TEST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](50) NULL,
	[REFERENCE_NUMBER] [int] NULL,
	[CREATED_BY] [varchar](30) NULL CONSTRAINT [DF_ZZ_UNIT_TEST_CREATED_BY]  DEFAULT ('SYSTEM'),
	[CREATED_DATETIME] [datetime] NULL CONSTRAINT [DF_ZZ_UNIT_TEST_CREATED_DATETIME]  DEFAULT (getdate()),
	[MODIFIED_BY] [varchar](30) NULL CONSTRAINT [DF_ZZ_UNIT_TEST_MODIFIED_BY]  DEFAULT ('SYSTEM'),
	[MODIFIED_DATETIME] [datetime] NULL CONSTRAINT [DF_ZZ_UNIT_TEST_MODIFIED_DATETIME]  DEFAULT (getdate()),
	[IS_DELETED] [tinyint] NULL,
	[TIMESTAMP] [timestamp] NOT NULL
) ON [PRIMARY]