CREATE DATABASE `Storeroom`;

USE `Storeroom`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `ProductProps` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Barcode` longtext CHARACTER SET utf8mb4 NULL,
    `ImageURL` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_ProductProps` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `ProductStatuses` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Type` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_ProductStatuses` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Products` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `ProductPropId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ProductStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    `FamilyId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Price` decimal(65,30) NOT NULL,
    `BoughtAt` datetime(6) NOT NULL,
    `ExpireAt` datetime(6) NOT NULL,
    CONSTRAINT `PK_Products` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Products_ProductProps_ProductPropId` FOREIGN KEY (`ProductPropId`) REFERENCES `ProductProps` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Products_ProductStatuses_ProductStatusId` FOREIGN KEY (`ProductStatusId`) REFERENCES `ProductStatuses` (`Id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE TABLE `Users` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
    `FullName` longtext CHARACTER SET utf8mb4 NULL,
    `FamilyId` char(36) COLLATE ascii_general_ci NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ImageURL` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Families` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `ManagerId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ImageURL` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Families` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Families_Users_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE UNIQUE INDEX `IX_Families_ManagerId` ON `Families` (`ManagerId`);

CREATE INDEX `IX_Products_FamilyId` ON `Products` (`FamilyId`);

CREATE INDEX `IX_Products_ProductPropId` ON `Products` (`ProductPropId`);

CREATE INDEX `IX_Products_ProductStatusId` ON `Products` (`ProductStatusId`);

CREATE INDEX `IX_Users_FamilyId` ON `Users` (`FamilyId`);

ALTER TABLE `Products` ADD CONSTRAINT `FK_Products_Families_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Families` (`Id`) ON DELETE CASCADE;

ALTER TABLE `Users` ADD CONSTRAINT `FK_Users_Families_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Families` (`Id`) ON DELETE RESTRICT;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220616170043_initMySql', '5.0.10');

INSERT INTO `ProductStatuses` (`Id`, `Type`)
VALUES ('F78D142B-57B0-4B71-B195-2EC2D3D467F3','New'),
    ('7894A85C-7A32-4BB0-845D-25B8796C0693','Open'),
    ('4CB17866-A95D-48DA-841A-8CB6843B2DA5','Garbage'),
    ('B9CBD9C4-2E5A-40A0-B196-6AE0A3187E28','Expired');

COMMIT;

