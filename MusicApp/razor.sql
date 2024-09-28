CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240717164836_MigrateToReinir', '8.0.7');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "AspNetRoles" (
    "Id" nvarchar(450) NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY,
    "Name" nvarchar(256) NULL,
    "NormalizedName" nvarchar(256) NULL,
    "ConcurrencyStamp" TEXT NULL
);

CREATE TABLE "AspNetUsers" (
    "Id" nvarchar(450) NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "CreatedAt" datetime2 NOT NULL,
    "ProfilePicture" TEXT NULL,
    "UserName" nvarchar(256) NULL,
    "NormalizedUserName" nvarchar(256) NULL,
    "Email" nvarchar(256) NULL,
    "NormalizedEmail" nvarchar(256) NULL,
    "EmailConfirmed" bit NOT NULL,
    "PasswordHash" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" bit NOT NULL,
    "TwoFactorEnabled" bit NOT NULL,
    "LockoutEnd" datetimeoffset NULL,
    "LockoutEnabled" bit NOT NULL,
    "AccessFailedCount" int NOT NULL
);

CREATE TABLE "Tracks" (
    "Id" int NOT NULL CONSTRAINT "PK_Tracks" PRIMARY KEY,
    "Title" nvarchar(100) NOT NULL,
    "YouTubeId" nvarchar(11) NOT NULL,
    "Duration" int NOT NULL,
    "ThumbnailUrl" TEXT NULL,
    "AddedAt" datetime2 NOT NULL
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" int NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY,
    "RoleId" nvarchar(450) NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" int NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY,
    "UserId" nvarchar(450) NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" nvarchar(450) NOT NULL,
    "ProviderKey" nvarchar(450) NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" nvarchar(450) NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" nvarchar(450) NOT NULL,
    "RoleId" nvarchar(450) NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" nvarchar(450) NOT NULL,
    "LoginProvider" nvarchar(450) NOT NULL,
    "Name" nvarchar(450) NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Playlists" (
    "Id" int NOT NULL CONSTRAINT "PK_Playlists" PRIMARY KEY,
    "Name" nvarchar(100) NOT NULL,
    "CreatedAt" datetime2 NOT NULL,
    "UserId" nvarchar(450) NULL,
    "IsPublic" bit NOT NULL,
    CONSTRAINT "FK_Playlists_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id")
);

CREATE TABLE "PlaylistTracks" (
    "Id" int NOT NULL CONSTRAINT "PK_PlaylistTracks" PRIMARY KEY,
    "PlaylistId" int NOT NULL,
    "TrackId" int NOT NULL,
    "Order" int NOT NULL,
    "AddedAt" datetime2 NOT NULL,
    CONSTRAINT "FK_PlaylistTracks_Playlists_PlaylistId" FOREIGN KEY ("PlaylistId") REFERENCES "Playlists" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlaylistTracks_Tracks_TrackId" FOREIGN KEY ("TrackId") REFERENCES "Tracks" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName") WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName") WHERE [NormalizedUserName] IS NOT NULL;

CREATE INDEX "IX_Playlists_UserId" ON "Playlists" ("UserId");

CREATE INDEX "IX_PlaylistTracks_PlaylistId" ON "PlaylistTracks" ("PlaylistId");

CREATE INDEX "IX_PlaylistTracks_TrackId" ON "PlaylistTracks" ("TrackId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240717205722_init', '8.0.7');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240717232903_reinir2', '8.0.7');

COMMIT;

BEGIN TRANSACTION;

DROP INDEX "UserNameIndex";

DROP INDEX "RoleNameIndex";

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE TABLE "ef_temp_Tracks" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Tracks" PRIMARY KEY AUTOINCREMENT,
    "AddedAt" TEXT NOT NULL,
    "Duration" INTEGER NOT NULL,
    "ThumbnailUrl" TEXT NULL,
    "Title" TEXT NOT NULL,
    "YouTubeId" TEXT NOT NULL
);

INSERT INTO "ef_temp_Tracks" ("Id", "AddedAt", "Duration", "ThumbnailUrl", "Title", "YouTubeId")
SELECT "Id", "AddedAt", "Duration", "ThumbnailUrl", "Title", "YouTubeId"
FROM "Tracks";

CREATE TABLE "ef_temp_PlaylistTracks" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PlaylistTracks" PRIMARY KEY AUTOINCREMENT,
    "AddedAt" TEXT NOT NULL,
    "Order" INTEGER NOT NULL,
    "PlaylistId" INTEGER NOT NULL,
    "TrackId" INTEGER NOT NULL,
    CONSTRAINT "FK_PlaylistTracks_Playlists_PlaylistId" FOREIGN KEY ("PlaylistId") REFERENCES "Playlists" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlaylistTracks_Tracks_TrackId" FOREIGN KEY ("TrackId") REFERENCES "Tracks" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_PlaylistTracks" ("Id", "AddedAt", "Order", "PlaylistId", "TrackId")
SELECT "Id", "AddedAt", "Order", "PlaylistId", "TrackId"
FROM "PlaylistTracks";

CREATE TABLE "ef_temp_Playlists" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Playlists" PRIMARY KEY AUTOINCREMENT,
    "CreatedAt" TEXT NOT NULL,
    "IsPublic" INTEGER NOT NULL,
    "Name" TEXT NOT NULL,
    "UserId" TEXT NULL,
    CONSTRAINT "FK_Playlists_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id")
);

INSERT INTO "ef_temp_Playlists" ("Id", "CreatedAt", "IsPublic", "Name", "UserId")
SELECT "Id", "CreatedAt", "IsPublic", "Name", "UserId"
FROM "Playlists";

CREATE TABLE "ef_temp_AspNetUserTokens" (
    "UserId" TEXT NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value")
SELECT "UserId", "LoginProvider", "Name", "Value"
FROM "AspNetUserTokens";

CREATE TABLE "ef_temp_AspNetUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "AccessFailedCount" INTEGER NOT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "CreatedAt" TEXT NOT NULL,
    "Email" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "PasswordHash" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "ProfilePicture" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "UserName" TEXT NULL
);

INSERT INTO "ef_temp_AspNetUsers" ("Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName")
SELECT "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName"
FROM "AspNetUsers";

CREATE TABLE "ef_temp_AspNetUserRoles" (
    "UserId" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_AspNetUserRoles" ("UserId", "RoleId")
SELECT "UserId", "RoleId"
FROM "AspNetUserRoles";

CREATE TABLE "ef_temp_AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId")
SELECT "LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId"
FROM "AspNetUserLogins";

CREATE TABLE "ef_temp_AspNetUserClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY AUTOINCREMENT,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_AspNetUserClaims" ("Id", "ClaimType", "ClaimValue", "UserId")
SELECT "Id", "ClaimType", "ClaimValue", "UserId"
FROM "AspNetUserClaims";

CREATE TABLE "ef_temp_AspNetRoles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY,
    "ConcurrencyStamp" TEXT NULL,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL
);

INSERT INTO "ef_temp_AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
SELECT "Id", "ConcurrencyStamp", "Name", "NormalizedName"
FROM "AspNetRoles";

CREATE TABLE "ef_temp_AspNetRoleClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY AUTOINCREMENT,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    "RoleId" TEXT NOT NULL,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_AspNetRoleClaims" ("Id", "ClaimType", "ClaimValue", "RoleId")
SELECT "Id", "ClaimType", "ClaimValue", "RoleId"
FROM "AspNetRoleClaims";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Tracks";

ALTER TABLE "ef_temp_Tracks" RENAME TO "Tracks";

DROP TABLE "PlaylistTracks";

ALTER TABLE "ef_temp_PlaylistTracks" RENAME TO "PlaylistTracks";

DROP TABLE "Playlists";

ALTER TABLE "ef_temp_Playlists" RENAME TO "Playlists";

DROP TABLE "AspNetUserTokens";

ALTER TABLE "ef_temp_AspNetUserTokens" RENAME TO "AspNetUserTokens";

DROP TABLE "AspNetUsers";

ALTER TABLE "ef_temp_AspNetUsers" RENAME TO "AspNetUsers";

DROP TABLE "AspNetUserRoles";

ALTER TABLE "ef_temp_AspNetUserRoles" RENAME TO "AspNetUserRoles";

DROP TABLE "AspNetUserLogins";

ALTER TABLE "ef_temp_AspNetUserLogins" RENAME TO "AspNetUserLogins";

DROP TABLE "AspNetUserClaims";

ALTER TABLE "ef_temp_AspNetUserClaims" RENAME TO "AspNetUserClaims";

DROP TABLE "AspNetRoles";

ALTER TABLE "ef_temp_AspNetRoles" RENAME TO "AspNetRoles";

DROP TABLE "AspNetRoleClaims";

ALTER TABLE "ef_temp_AspNetRoleClaims" RENAME TO "AspNetRoleClaims";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_PlaylistTracks_PlaylistId" ON "PlaylistTracks" ("PlaylistId");

CREATE INDEX "IX_PlaylistTracks_TrackId" ON "PlaylistTracks" ("TrackId");

CREATE INDEX "IX_Playlists_UserId" ON "Playlists" ("UserId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240717235203_reinir3', '8.0.7');

COMMIT;


