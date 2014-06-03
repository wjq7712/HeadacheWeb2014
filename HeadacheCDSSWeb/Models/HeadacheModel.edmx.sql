
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2013 22:57:17
-- Generated from EDMX file: E:\可变动程序(77)\NewheadacheWeb\HeadacheCDSSWeb\Models\HeadacheModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HeadacheDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DoctorAccountPatBasicInfor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_DoctorAccountPatBasicInfor];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadachaOverViewHeadachePlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadachePlaceSet] DROP CONSTRAINT [FK_HeadachaOverViewHeadachePlace];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadachaOverViewHeadacheAccompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadacheAccompanySet] DROP CONSTRAINT [FK_HeadachaOverViewHeadacheAccompany];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadachaOverViewHeadacheProdrome]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadacheProdromeSet] DROP CONSTRAINT [FK_HeadachaOverViewHeadacheProdrome];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadachaOverViewMitigatingFactors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigatingFactorsSet] DROP CONSTRAINT [FK_HeadachaOverViewMitigatingFactors];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadachaOverViewPrecipitatingFactor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrecipitatingFactorSet] DROP CONSTRAINT [FK_HeadachaOverViewPrecipitatingFactor];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPreviousExam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreviousExamSet] DROP CONSTRAINT [FK_PatBasicInforPreviousExam];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforHeadacheFamilyMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadacheFamilyMemberSet] DROP CONSTRAINT [FK_PatBasicInforHeadacheFamilyMember];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforOtherFamilyDisease]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OtherFamilyDiseaseSet] DROP CONSTRAINT [FK_PatBasicInforOtherFamilyDisease];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordSecondaryHeadacheSymptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SecondaryHeadacheSymptomSet] DROP CONSTRAINT [FK_VisitRecordSecondaryHeadacheSymptom];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPrimaryHeadachaOverView]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrimaryHeadacheOverViewSet] DROP CONSTRAINT [FK_VisitRecordPrimaryHeadachaOverView];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforLifestyle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_PatBasicInforLifestyle];
GO
IF OBJECT_ID(N'[dbo].[FK_PrimaryHeadacheOverViewPremonitorySymptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PremonitorySymptom集] DROP CONSTRAINT [FK_PrimaryHeadacheOverViewPremonitorySymptom];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordGADQuestionaire]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GADQuestionaireSet] DROP CONSTRAINT [FK_VisitRecordGADQuestionaire];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPHQuestionaire]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHQuestionaireSet] DROP CONSTRAINT [FK_VisitRecordPHQuestionaire];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordSleepStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SleepStatusSet] DROP CONSTRAINT [FK_VisitRecordSleepStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordDisabilityEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisabilityEvaluationSet] DROP CONSTRAINT [FK_VisitRecordDisabilityEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadacheDiaryHDAcompanion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HDAcompanionSet] DROP CONSTRAINT [FK_HeadacheDiaryHDAcompanion];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadacheDiaryHDheadacheplace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HDheadacheplaceSet] DROP CONSTRAINT [FK_HeadacheDiaryHDheadacheplace];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadacheDiaryHDHeadacheProdrome]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HDHeadacheProdromeSet] DROP CONSTRAINT [FK_HeadacheDiaryHDHeadacheProdrome];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadacheDiaryHDMitigatingFactors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HDMitigatingFactorsSet] DROP CONSTRAINT [FK_HeadacheDiaryHDMitigatingFactors];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadacheDiaryHDPrecipitatingFactor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HDPrecipitatingFactorSet] DROP CONSTRAINT [FK_HeadacheDiaryHDPrecipitatingFactor];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforHeadacheDiary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadacheDiarySet] DROP CONSTRAINT [FK_PatBasicInforHeadacheDiary];
GO
IF OBJECT_ID(N'[dbo].[FK_NationalCenterAccountRegionalCenterAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionalCenterAccountSet] DROP CONSTRAINT [FK_NationalCenterAccountRegionalCenterAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionalCenterAccountDoctorAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoctorAccountSet] DROP CONSTRAINT [FK_RegionalCenterAccountDoctorAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforVisitRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitRecordSet] DROP CONSTRAINT [FK_PatBasicInforVisitRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPreviousDrug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreviousDrugSet] DROP CONSTRAINT [FK_PatBasicInforPreviousDrug];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordMedicationAdvice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MedicationAdviceSet] DROP CONSTRAINT [FK_VisitRecordMedicationAdvice];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPatinfoForRe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatinfoForReSet] DROP CONSTRAINT [FK_PatBasicInforPatinfoForRe];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DoctorAccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoctorAccountSet];
GO
IF OBJECT_ID(N'[dbo].[PatBasicInforSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatBasicInforSet];
GO
IF OBJECT_ID(N'[dbo].[VisitRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitRecordSet];
GO
IF OBJECT_ID(N'[dbo].[PrimaryHeadacheOverViewSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrimaryHeadacheOverViewSet];
GO
IF OBJECT_ID(N'[dbo].[LifestyleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LifestyleSet];
GO
IF OBJECT_ID(N'[dbo].[HeadachePlaceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeadachePlaceSet];
GO
IF OBJECT_ID(N'[dbo].[HeadacheAccompanySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeadacheAccompanySet];
GO
IF OBJECT_ID(N'[dbo].[HeadacheProdromeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeadacheProdromeSet];
GO
IF OBJECT_ID(N'[dbo].[PreviousDrugSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PreviousDrugSet];
GO
IF OBJECT_ID(N'[dbo].[PreviousExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PreviousExamSet];
GO
IF OBJECT_ID(N'[dbo].[HeadacheFamilyMemberSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeadacheFamilyMemberSet];
GO
IF OBJECT_ID(N'[dbo].[OtherFamilyDiseaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OtherFamilyDiseaseSet];
GO
IF OBJECT_ID(N'[dbo].[MedicationAdviceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MedicationAdviceSet];
GO
IF OBJECT_ID(N'[dbo].[PrecipitatingFactorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrecipitatingFactorSet];
GO
IF OBJECT_ID(N'[dbo].[MitigatingFactorsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigatingFactorsSet];
GO
IF OBJECT_ID(N'[dbo].[SecondaryHeadacheSymptomSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecondaryHeadacheSymptomSet];
GO
IF OBJECT_ID(N'[dbo].[PremonitorySymptom集]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PremonitorySymptom集];
GO
IF OBJECT_ID(N'[dbo].[PHQuestionaireSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHQuestionaireSet];
GO
IF OBJECT_ID(N'[dbo].[GADQuestionaireSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GADQuestionaireSet];
GO
IF OBJECT_ID(N'[dbo].[DisabilityEvaluationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisabilityEvaluationSet];
GO
IF OBJECT_ID(N'[dbo].[SleepStatusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SleepStatusSet];
GO
IF OBJECT_ID(N'[dbo].[HeadacheDiarySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeadacheDiarySet];
GO
IF OBJECT_ID(N'[dbo].[HDheadacheplaceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HDheadacheplaceSet];
GO
IF OBJECT_ID(N'[dbo].[HDAcompanionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HDAcompanionSet];
GO
IF OBJECT_ID(N'[dbo].[HDPrecipitatingFactorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HDPrecipitatingFactorSet];
GO
IF OBJECT_ID(N'[dbo].[HDMitigatingFactorsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HDMitigatingFactorsSet];
GO
IF OBJECT_ID(N'[dbo].[HDHeadacheProdromeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HDHeadacheProdromeSet];
GO
IF OBJECT_ID(N'[dbo].[RegionalCenterAccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionalCenterAccountSet];
GO
IF OBJECT_ID(N'[dbo].[NationalCenterAccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NationalCenterAccountSet];
GO
IF OBJECT_ID(N'[dbo].[PatinfoForReSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatinfoForReSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DoctorAccountSet'
CREATE TABLE [dbo].[DoctorAccountSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL,
    [Hospital] nvarchar(max)  NOT NULL,
    [ChiefDoctor] nvarchar(max)  NOT NULL,
    [RegionalCenterAccountID] int  NOT NULL
);
GO

-- Creating table 'PatBasicInforSet'
CREATE TABLE [dbo].[PatBasicInforSet] (
    [Id] nvarchar(255)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Education] nvarchar(max)  NULL,
    [Job] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Identity] nvarchar(max)  NULL,
    [DoctorAccountId] int  NOT NULL,
    [SimilarFamily] bit  NULL,
    [Weight] nvarchar(max)  NULL,
    [Height] nvarchar(max)  NULL,
    [Lifestyle_Id] int  NOT NULL
);
GO

-- Creating table 'VisitRecordSet'
CREATE TABLE [dbo].[VisitRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OutpatientID] nvarchar(max)  NULL,
    [ChiefComplaint] nvarchar(max)  NOT NULL,
    [VisitDate] datetime  NOT NULL,
    [CDSSDiagnosis1] nvarchar(max)  NOT NULL,
    [CDSSDiagnosis2] nvarchar(max)  NULL,
    [CDSSDiagnosis3] nvarchar(max)  NULL,
    [DiagnosisResult1] nvarchar(max)  NOT NULL,
    [DiagnosisResult2] nvarchar(max)  NULL,
    [DiagnosisResult3] nvarchar(max)  NULL,
    [Prescription] nvarchar(max)  NULL,
    [PreviousDiagnosis] nvarchar(max)  NULL,
    [PrescriptionNote] nvarchar(max)  NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'PrimaryHeadacheOverViewSet'
CREATE TABLE [dbo].[PrimaryHeadacheOverViewSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HeadacheType] nvarchar(max)  NOT NULL,
    [HeadacheDegree] nvarchar(max)  NOT NULL,
    [HeadcheTime] nvarchar(max)  NOT NULL,
    [HeacheTimeUnit] nvarchar(max)  NOT NULL,
    [FrequencyPerMonth] nvarchar(max)  NOT NULL,
    [OnsetFixedPeriod] nvarchar(max)  NOT NULL,
    [OnsetDate] datetime  NOT NULL,
    [OnsetAmount] nvarchar(max)  NOT NULL,
    [DailyAggravation] nvarchar(max)  NOT NULL,
    [FirstOnsetContinue] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'LifestyleSet'
CREATE TABLE [dbo].[LifestyleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SmokeState] bit  NULL,
    [SmokeYear] nvarchar(max)  NULL,
    [DrinkState] bit  NULL,
    [DrinkYear] nvarchar(max)  NULL,
    [TeaPerDay] nvarchar(max)  NULL,
    [CoffePerDay] nvarchar(max)  NULL,
    [ExerciseOften] bit  NULL
);
GO

-- Creating table 'HeadachePlaceSet'
CREATE TABLE [dbo].[HeadachePlaceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [SpecificPlace] nvarchar(max)  NOT NULL,
    [HeadachaOverViewId] int  NOT NULL
);
GO

-- Creating table 'HeadacheAccompanySet'
CREATE TABLE [dbo].[HeadacheAccompanySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Symptom] nvarchar(max)  NOT NULL,
    [HeadachaOverViewId] int  NOT NULL
);
GO

-- Creating table 'HeadacheProdromeSet'
CREATE TABLE [dbo].[HeadacheProdromeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Prodrome] nvarchar(max)  NOT NULL,
    [HeadachaOverViewId] int  NOT NULL
);
GO

-- Creating table 'PreviousDrugSet'
CREATE TABLE [dbo].[PreviousDrugSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugCategory] nvarchar(max)  NOT NULL,
    [DrugName] nvarchar(max)  NOT NULL,
    [DayAmoutnPerM] nvarchar(max)  NULL,
    [MonthTotalAmount] nvarchar(max)  NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL,
    [DrugApplication] nvarchar(max)  NULL,
    [PatBasicInforId1] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'PreviousExamSet'
CREATE TABLE [dbo].[PreviousExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExamName] nvarchar(max)  NOT NULL,
    [Result] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'HeadacheFamilyMemberSet'
CREATE TABLE [dbo].[HeadacheFamilyMemberSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Person] nvarchar(max)  NOT NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'OtherFamilyDiseaseSet'
CREATE TABLE [dbo].[OtherFamilyDiseaseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DiseaseName] nvarchar(max)  NOT NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'MedicationAdviceSet'
CREATE TABLE [dbo].[MedicationAdviceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugApplication] nvarchar(max)  NULL,
    [DrugCategory] nvarchar(max)  NULL,
    [DrugName] nvarchar(max)  NULL,
    [DrugDose] nvarchar(max)  NULL,
    [DrugDoseUnit] nvarchar(max)  NULL,
    [VisitRecordId] int  NOT NULL
);
GO

-- Creating table 'PrecipitatingFactorSet'
CREATE TABLE [dbo].[PrecipitatingFactorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FactorName] nvarchar(max)  NOT NULL,
    [HeadachaOverViewId] int  NOT NULL,
    [FactorDetail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MitigatingFactorsSet'
CREATE TABLE [dbo].[MitigatingFactorsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FactorName] nvarchar(max)  NOT NULL,
    [HeadachaOverViewId] int  NOT NULL
);
GO

-- Creating table 'SecondaryHeadacheSymptomSet'
CREATE TABLE [dbo].[SecondaryHeadacheSymptomSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Symptom] nvarchar(max)  NOT NULL,
    [VisitRecordId] int  NOT NULL
);
GO

-- Creating table 'PremonitorySymptom集'
CREATE TABLE [dbo].[PremonitorySymptom集] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Symptom] nvarchar(max)  NULL,
    [PrimaryHeadacheOverViewId] int  NOT NULL
);
GO

-- Creating table 'PHQuestionaireSet'
CREATE TABLE [dbo].[PHQuestionaireSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Q1] nvarchar(max)  NULL,
    [Q2] nvarchar(max)  NULL,
    [Q3] nvarchar(max)  NULL,
    [Q4] nvarchar(max)  NULL,
    [Q5] nvarchar(max)  NULL,
    [Q6] nvarchar(max)  NULL,
    [Q7] nvarchar(max)  NULL,
    [Q8] nvarchar(max)  NULL,
    [Q9] nvarchar(max)  NULL,
    [TotalScore] nvarchar(max)  NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'GADQuestionaireSet'
CREATE TABLE [dbo].[GADQuestionaireSet] (
    [Q1] nvarchar(max)  NULL,
    [Q2] nvarchar(max)  NULL,
    [Q3] nvarchar(max)  NULL,
    [Q4] nvarchar(max)  NULL,
    [Q5] nvarchar(max)  NULL,
    [Q6] nvarchar(max)  NULL,
    [Q7] nvarchar(max)  NULL,
    [TotalScore] nvarchar(max)  NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'DisabilityEvaluationSet'
CREATE TABLE [dbo].[DisabilityEvaluationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HeadacheDays] nvarchar(max)  NULL,
    [OutOfWorkDays] nvarchar(max)  NULL,
    [AffectWorkDays] nvarchar(max)  NULL,
    [OutOfHouseWorkDays] nvarchar(max)  NULL,
    [AffectHouseWorkDays] nvarchar(max)  NULL,
    [MissActivityDays] nvarchar(max)  NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'SleepStatusSet'
CREATE TABLE [dbo].[SleepStatusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimePerDay] nvarchar(max)  NULL,
    [DifficultFallingAsleep] nvarchar(max)  NULL,
    [Dreaminess] nvarchar(max)  NULL,
    [FestlessSleep] nvarchar(max)  NULL,
    [SleepyDayTime] nvarchar(max)  NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'HeadacheDiarySet'
CREATE TABLE [dbo].[HeadacheDiarySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RecordDate] datetime  NOT NULL,
    [HeadacheTime] int  NOT NULL,
    [HeadacheType] nvarchar(max)  NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL,
    [HeadacheDegree] int  NOT NULL
);
GO

-- Creating table 'HDheadacheplaceSet'
CREATE TABLE [dbo].[HDheadacheplaceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [postion] nvarchar(max)  NOT NULL,
    [HeadacheDiaryID] int  NOT NULL,
    [detailposition] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HDAcompanionSet'
CREATE TABLE [dbo].[HDAcompanionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [symptom] nvarchar(max)  NOT NULL,
    [HeadacheDiaryID] int  NOT NULL
);
GO

-- Creating table 'HDPrecipitatingFactorSet'
CREATE TABLE [dbo].[HDPrecipitatingFactorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [factor] nvarchar(max)  NOT NULL,
    [HeadacheDiaryID] int  NOT NULL
);
GO

-- Creating table 'HDMitigatingFactorsSet'
CREATE TABLE [dbo].[HDMitigatingFactorsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [factor] nvarchar(max)  NOT NULL,
    [HeadacheDiaryID] int  NOT NULL
);
GO

-- Creating table 'HDHeadacheProdromeSet'
CREATE TABLE [dbo].[HDHeadacheProdromeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [symptom] nvarchar(max)  NOT NULL,
    [HeadacheDiaryID] int  NOT NULL
);
GO

-- Creating table 'RegionalCenterAccountSet'
CREATE TABLE [dbo].[RegionalCenterAccountSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [NationalCenterAccountID] int  NOT NULL
);
GO

-- Creating table 'NationalCenterAccountSet'
CREATE TABLE [dbo].[NationalCenterAccountSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PatinfoForReSet'
CREATE TABLE [dbo].[PatinfoForReSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [HeadacheStyle] nvarchar(max)  NOT NULL,
    [Data] datetime  NOT NULL,
    [PatBasicInforId] nvarchar(max)  NOT NULL,
    [PatBasicInfor_Id] nvarchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DoctorAccountSet'
ALTER TABLE [dbo].[DoctorAccountSet]
ADD CONSTRAINT [PK_DoctorAccountSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [PK_PatBasicInforSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VisitRecordSet'
ALTER TABLE [dbo].[VisitRecordSet]
ADD CONSTRAINT [PK_VisitRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrimaryHeadacheOverViewSet'
ALTER TABLE [dbo].[PrimaryHeadacheOverViewSet]
ADD CONSTRAINT [PK_PrimaryHeadacheOverViewSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LifestyleSet'
ALTER TABLE [dbo].[LifestyleSet]
ADD CONSTRAINT [PK_LifestyleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HeadachePlaceSet'
ALTER TABLE [dbo].[HeadachePlaceSet]
ADD CONSTRAINT [PK_HeadachePlaceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HeadacheAccompanySet'
ALTER TABLE [dbo].[HeadacheAccompanySet]
ADD CONSTRAINT [PK_HeadacheAccompanySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HeadacheProdromeSet'
ALTER TABLE [dbo].[HeadacheProdromeSet]
ADD CONSTRAINT [PK_HeadacheProdromeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PreviousDrugSet'
ALTER TABLE [dbo].[PreviousDrugSet]
ADD CONSTRAINT [PK_PreviousDrugSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PreviousExamSet'
ALTER TABLE [dbo].[PreviousExamSet]
ADD CONSTRAINT [PK_PreviousExamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HeadacheFamilyMemberSet'
ALTER TABLE [dbo].[HeadacheFamilyMemberSet]
ADD CONSTRAINT [PK_HeadacheFamilyMemberSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OtherFamilyDiseaseSet'
ALTER TABLE [dbo].[OtherFamilyDiseaseSet]
ADD CONSTRAINT [PK_OtherFamilyDiseaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MedicationAdviceSet'
ALTER TABLE [dbo].[MedicationAdviceSet]
ADD CONSTRAINT [PK_MedicationAdviceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrecipitatingFactorSet'
ALTER TABLE [dbo].[PrecipitatingFactorSet]
ADD CONSTRAINT [PK_PrecipitatingFactorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MitigatingFactorsSet'
ALTER TABLE [dbo].[MitigatingFactorsSet]
ADD CONSTRAINT [PK_MitigatingFactorsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecondaryHeadacheSymptomSet'
ALTER TABLE [dbo].[SecondaryHeadacheSymptomSet]
ADD CONSTRAINT [PK_SecondaryHeadacheSymptomSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PremonitorySymptom集'
ALTER TABLE [dbo].[PremonitorySymptom集]
ADD CONSTRAINT [PK_PremonitorySymptom集]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PHQuestionaireSet'
ALTER TABLE [dbo].[PHQuestionaireSet]
ADD CONSTRAINT [PK_PHQuestionaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GADQuestionaireSet'
ALTER TABLE [dbo].[GADQuestionaireSet]
ADD CONSTRAINT [PK_GADQuestionaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DisabilityEvaluationSet'
ALTER TABLE [dbo].[DisabilityEvaluationSet]
ADD CONSTRAINT [PK_DisabilityEvaluationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SleepStatusSet'
ALTER TABLE [dbo].[SleepStatusSet]
ADD CONSTRAINT [PK_SleepStatusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HeadacheDiarySet'
ALTER TABLE [dbo].[HeadacheDiarySet]
ADD CONSTRAINT [PK_HeadacheDiarySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HDheadacheplaceSet'
ALTER TABLE [dbo].[HDheadacheplaceSet]
ADD CONSTRAINT [PK_HDheadacheplaceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HDAcompanionSet'
ALTER TABLE [dbo].[HDAcompanionSet]
ADD CONSTRAINT [PK_HDAcompanionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HDPrecipitatingFactorSet'
ALTER TABLE [dbo].[HDPrecipitatingFactorSet]
ADD CONSTRAINT [PK_HDPrecipitatingFactorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HDMitigatingFactorsSet'
ALTER TABLE [dbo].[HDMitigatingFactorsSet]
ADD CONSTRAINT [PK_HDMitigatingFactorsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HDHeadacheProdromeSet'
ALTER TABLE [dbo].[HDHeadacheProdromeSet]
ADD CONSTRAINT [PK_HDHeadacheProdromeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'RegionalCenterAccountSet'
ALTER TABLE [dbo].[RegionalCenterAccountSet]
ADD CONSTRAINT [PK_RegionalCenterAccountSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'NationalCenterAccountSet'
ALTER TABLE [dbo].[NationalCenterAccountSet]
ADD CONSTRAINT [PK_NationalCenterAccountSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'PatinfoForReSet'
ALTER TABLE [dbo].[PatinfoForReSet]
ADD CONSTRAINT [PK_PatinfoForReSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DoctorAccountId] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [FK_DoctorAccountPatBasicInfor]
    FOREIGN KEY ([DoctorAccountId])
    REFERENCES [dbo].[DoctorAccountSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorAccountPatBasicInfor'
CREATE INDEX [IX_FK_DoctorAccountPatBasicInfor]
ON [dbo].[PatBasicInforSet]
    ([DoctorAccountId]);
GO

-- Creating foreign key on [HeadachaOverViewId] in table 'HeadachePlaceSet'
ALTER TABLE [dbo].[HeadachePlaceSet]
ADD CONSTRAINT [FK_HeadachaOverViewHeadachePlace]
    FOREIGN KEY ([HeadachaOverViewId])
    REFERENCES [dbo].[PrimaryHeadacheOverViewSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadachaOverViewHeadachePlace'
CREATE INDEX [IX_FK_HeadachaOverViewHeadachePlace]
ON [dbo].[HeadachePlaceSet]
    ([HeadachaOverViewId]);
GO

-- Creating foreign key on [HeadachaOverViewId] in table 'HeadacheAccompanySet'
ALTER TABLE [dbo].[HeadacheAccompanySet]
ADD CONSTRAINT [FK_HeadachaOverViewHeadacheAccompany]
    FOREIGN KEY ([HeadachaOverViewId])
    REFERENCES [dbo].[PrimaryHeadacheOverViewSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadachaOverViewHeadacheAccompany'
CREATE INDEX [IX_FK_HeadachaOverViewHeadacheAccompany]
ON [dbo].[HeadacheAccompanySet]
    ([HeadachaOverViewId]);
GO

-- Creating foreign key on [HeadachaOverViewId] in table 'HeadacheProdromeSet'
ALTER TABLE [dbo].[HeadacheProdromeSet]
ADD CONSTRAINT [FK_HeadachaOverViewHeadacheProdrome]
    FOREIGN KEY ([HeadachaOverViewId])
    REFERENCES [dbo].[PrimaryHeadacheOverViewSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadachaOverViewHeadacheProdrome'
CREATE INDEX [IX_FK_HeadachaOverViewHeadacheProdrome]
ON [dbo].[HeadacheProdromeSet]
    ([HeadachaOverViewId]);
GO

-- Creating foreign key on [HeadachaOverViewId] in table 'MitigatingFactorsSet'
ALTER TABLE [dbo].[MitigatingFactorsSet]
ADD CONSTRAINT [FK_HeadachaOverViewMitigatingFactors]
    FOREIGN KEY ([HeadachaOverViewId])
    REFERENCES [dbo].[PrimaryHeadacheOverViewSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadachaOverViewMitigatingFactors'
CREATE INDEX [IX_FK_HeadachaOverViewMitigatingFactors]
ON [dbo].[MitigatingFactorsSet]
    ([HeadachaOverViewId]);
GO

-- Creating foreign key on [HeadachaOverViewId] in table 'PrecipitatingFactorSet'
ALTER TABLE [dbo].[PrecipitatingFactorSet]
ADD CONSTRAINT [FK_HeadachaOverViewPrecipitatingFactor]
    FOREIGN KEY ([HeadachaOverViewId])
    REFERENCES [dbo].[PrimaryHeadacheOverViewSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadachaOverViewPrecipitatingFactor'
CREATE INDEX [IX_FK_HeadachaOverViewPrecipitatingFactor]
ON [dbo].[PrecipitatingFactorSet]
    ([HeadachaOverViewId]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'PreviousExamSet'
ALTER TABLE [dbo].[PreviousExamSet]
ADD CONSTRAINT [FK_PatBasicInforPreviousExam]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforPreviousExam'
CREATE INDEX [IX_FK_PatBasicInforPreviousExam]
ON [dbo].[PreviousExamSet]
    ([PatBasicInforId]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'HeadacheFamilyMemberSet'
ALTER TABLE [dbo].[HeadacheFamilyMemberSet]
ADD CONSTRAINT [FK_PatBasicInforHeadacheFamilyMember]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforHeadacheFamilyMember'
CREATE INDEX [IX_FK_PatBasicInforHeadacheFamilyMember]
ON [dbo].[HeadacheFamilyMemberSet]
    ([PatBasicInforId]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'OtherFamilyDiseaseSet'
ALTER TABLE [dbo].[OtherFamilyDiseaseSet]
ADD CONSTRAINT [FK_PatBasicInforOtherFamilyDisease]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforOtherFamilyDisease'
CREATE INDEX [IX_FK_PatBasicInforOtherFamilyDisease]
ON [dbo].[OtherFamilyDiseaseSet]
    ([PatBasicInforId]);
GO

-- Creating foreign key on [VisitRecordId] in table 'SecondaryHeadacheSymptomSet'
ALTER TABLE [dbo].[SecondaryHeadacheSymptomSet]
ADD CONSTRAINT [FK_VisitRecordSecondaryHeadacheSymptom]
    FOREIGN KEY ([VisitRecordId])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordSecondaryHeadacheSymptom'
CREATE INDEX [IX_FK_VisitRecordSecondaryHeadacheSymptom]
ON [dbo].[SecondaryHeadacheSymptomSet]
    ([VisitRecordId]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PrimaryHeadacheOverViewSet'
ALTER TABLE [dbo].[PrimaryHeadacheOverViewSet]
ADD CONSTRAINT [FK_VisitRecordPrimaryHeadachaOverView]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPrimaryHeadachaOverView'
CREATE INDEX [IX_FK_VisitRecordPrimaryHeadachaOverView]
ON [dbo].[PrimaryHeadacheOverViewSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [Lifestyle_Id] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [FK_PatBasicInforLifestyle]
    FOREIGN KEY ([Lifestyle_Id])
    REFERENCES [dbo].[LifestyleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforLifestyle'
CREATE INDEX [IX_FK_PatBasicInforLifestyle]
ON [dbo].[PatBasicInforSet]
    ([Lifestyle_Id]);
GO

-- Creating foreign key on [PrimaryHeadacheOverViewId] in table 'PremonitorySymptom集'
ALTER TABLE [dbo].[PremonitorySymptom集]
ADD CONSTRAINT [FK_PrimaryHeadacheOverViewPremonitorySymptom]
    FOREIGN KEY ([PrimaryHeadacheOverViewId])
    REFERENCES [dbo].[PrimaryHeadacheOverViewSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PrimaryHeadacheOverViewPremonitorySymptom'
CREATE INDEX [IX_FK_PrimaryHeadacheOverViewPremonitorySymptom]
ON [dbo].[PremonitorySymptom集]
    ([PrimaryHeadacheOverViewId]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'GADQuestionaireSet'
ALTER TABLE [dbo].[GADQuestionaireSet]
ADD CONSTRAINT [FK_VisitRecordGADQuestionaire]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordGADQuestionaire'
CREATE INDEX [IX_FK_VisitRecordGADQuestionaire]
ON [dbo].[GADQuestionaireSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PHQuestionaireSet'
ALTER TABLE [dbo].[PHQuestionaireSet]
ADD CONSTRAINT [FK_VisitRecordPHQuestionaire]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPHQuestionaire'
CREATE INDEX [IX_FK_VisitRecordPHQuestionaire]
ON [dbo].[PHQuestionaireSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'SleepStatusSet'
ALTER TABLE [dbo].[SleepStatusSet]
ADD CONSTRAINT [FK_VisitRecordSleepStatus]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordSleepStatus'
CREATE INDEX [IX_FK_VisitRecordSleepStatus]
ON [dbo].[SleepStatusSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'DisabilityEvaluationSet'
ALTER TABLE [dbo].[DisabilityEvaluationSet]
ADD CONSTRAINT [FK_VisitRecordDisabilityEvaluation]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordDisabilityEvaluation'
CREATE INDEX [IX_FK_VisitRecordDisabilityEvaluation]
ON [dbo].[DisabilityEvaluationSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [HeadacheDiaryID] in table 'HDAcompanionSet'
ALTER TABLE [dbo].[HDAcompanionSet]
ADD CONSTRAINT [FK_HeadacheDiaryHDAcompanion]
    FOREIGN KEY ([HeadacheDiaryID])
    REFERENCES [dbo].[HeadacheDiarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadacheDiaryHDAcompanion'
CREATE INDEX [IX_FK_HeadacheDiaryHDAcompanion]
ON [dbo].[HDAcompanionSet]
    ([HeadacheDiaryID]);
GO

-- Creating foreign key on [HeadacheDiaryID] in table 'HDheadacheplaceSet'
ALTER TABLE [dbo].[HDheadacheplaceSet]
ADD CONSTRAINT [FK_HeadacheDiaryHDheadacheplace]
    FOREIGN KEY ([HeadacheDiaryID])
    REFERENCES [dbo].[HeadacheDiarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadacheDiaryHDheadacheplace'
CREATE INDEX [IX_FK_HeadacheDiaryHDheadacheplace]
ON [dbo].[HDheadacheplaceSet]
    ([HeadacheDiaryID]);
GO

-- Creating foreign key on [HeadacheDiaryID] in table 'HDHeadacheProdromeSet'
ALTER TABLE [dbo].[HDHeadacheProdromeSet]
ADD CONSTRAINT [FK_HeadacheDiaryHDHeadacheProdrome]
    FOREIGN KEY ([HeadacheDiaryID])
    REFERENCES [dbo].[HeadacheDiarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadacheDiaryHDHeadacheProdrome'
CREATE INDEX [IX_FK_HeadacheDiaryHDHeadacheProdrome]
ON [dbo].[HDHeadacheProdromeSet]
    ([HeadacheDiaryID]);
GO

-- Creating foreign key on [HeadacheDiaryID] in table 'HDMitigatingFactorsSet'
ALTER TABLE [dbo].[HDMitigatingFactorsSet]
ADD CONSTRAINT [FK_HeadacheDiaryHDMitigatingFactors]
    FOREIGN KEY ([HeadacheDiaryID])
    REFERENCES [dbo].[HeadacheDiarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadacheDiaryHDMitigatingFactors'
CREATE INDEX [IX_FK_HeadacheDiaryHDMitigatingFactors]
ON [dbo].[HDMitigatingFactorsSet]
    ([HeadacheDiaryID]);
GO

-- Creating foreign key on [HeadacheDiaryID] in table 'HDPrecipitatingFactorSet'
ALTER TABLE [dbo].[HDPrecipitatingFactorSet]
ADD CONSTRAINT [FK_HeadacheDiaryHDPrecipitatingFactor]
    FOREIGN KEY ([HeadacheDiaryID])
    REFERENCES [dbo].[HeadacheDiarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadacheDiaryHDPrecipitatingFactor'
CREATE INDEX [IX_FK_HeadacheDiaryHDPrecipitatingFactor]
ON [dbo].[HDPrecipitatingFactorSet]
    ([HeadacheDiaryID]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'HeadacheDiarySet'
ALTER TABLE [dbo].[HeadacheDiarySet]
ADD CONSTRAINT [FK_PatBasicInforHeadacheDiary]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforHeadacheDiary'
CREATE INDEX [IX_FK_PatBasicInforHeadacheDiary]
ON [dbo].[HeadacheDiarySet]
    ([PatBasicInforId]);
GO

-- Creating foreign key on [NationalCenterAccountID] in table 'RegionalCenterAccountSet'
ALTER TABLE [dbo].[RegionalCenterAccountSet]
ADD CONSTRAINT [FK_NationalCenterAccountRegionalCenterAccount]
    FOREIGN KEY ([NationalCenterAccountID])
    REFERENCES [dbo].[NationalCenterAccountSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NationalCenterAccountRegionalCenterAccount'
CREATE INDEX [IX_FK_NationalCenterAccountRegionalCenterAccount]
ON [dbo].[RegionalCenterAccountSet]
    ([NationalCenterAccountID]);
GO

-- Creating foreign key on [RegionalCenterAccountID] in table 'DoctorAccountSet'
ALTER TABLE [dbo].[DoctorAccountSet]
ADD CONSTRAINT [FK_RegionalCenterAccountDoctorAccount]
    FOREIGN KEY ([RegionalCenterAccountID])
    REFERENCES [dbo].[RegionalCenterAccountSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionalCenterAccountDoctorAccount'
CREATE INDEX [IX_FK_RegionalCenterAccountDoctorAccount]
ON [dbo].[DoctorAccountSet]
    ([RegionalCenterAccountID]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'VisitRecordSet'
ALTER TABLE [dbo].[VisitRecordSet]
ADD CONSTRAINT [FK_PatBasicInforVisitRecord]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforVisitRecord'
CREATE INDEX [IX_FK_PatBasicInforVisitRecord]
ON [dbo].[VisitRecordSet]
    ([PatBasicInforId]);
GO

-- Creating foreign key on [PatBasicInforId1] in table 'PreviousDrugSet'
ALTER TABLE [dbo].[PreviousDrugSet]
ADD CONSTRAINT [FK_PatBasicInforPreviousDrug]
    FOREIGN KEY ([PatBasicInforId1])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforPreviousDrug'
CREATE INDEX [IX_FK_PatBasicInforPreviousDrug]
ON [dbo].[PreviousDrugSet]
    ([PatBasicInforId1]);
GO

-- Creating foreign key on [VisitRecordId] in table 'MedicationAdviceSet'
ALTER TABLE [dbo].[MedicationAdviceSet]
ADD CONSTRAINT [FK_VisitRecordMedicationAdvice]
    FOREIGN KEY ([VisitRecordId])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordMedicationAdvice'
CREATE INDEX [IX_FK_VisitRecordMedicationAdvice]
ON [dbo].[MedicationAdviceSet]
    ([VisitRecordId]);
GO

-- Creating foreign key on [PatBasicInfor_Id] in table 'PatinfoForReSet'
ALTER TABLE [dbo].[PatinfoForReSet]
ADD CONSTRAINT [FK_PatBasicInforPatinfoForRe]
    FOREIGN KEY ([PatBasicInfor_Id])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforPatinfoForRe'
CREATE INDEX [IX_FK_PatBasicInforPatinfoForRe]
ON [dbo].[PatinfoForReSet]
    ([PatBasicInfor_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------