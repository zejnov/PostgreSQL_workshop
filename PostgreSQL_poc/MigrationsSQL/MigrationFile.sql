CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" varchar(150) NOT NULL,
    "ProductVersion" varchar(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Blogs" (
    "BlogId" serial NOT NULL,
    "Url" text NULL,
    CONSTRAINT "PK_Blogs" PRIMARY KEY ("BlogId")
);

CREATE TABLE "Posts" (
    "PostId" serial NOT NULL,
    "BlogId" int4 NOT NULL,
    "Content" text NULL,
    "Title" text NULL,
    CONSTRAINT "PK_Posts" PRIMARY KEY ("PostId"),
    CONSTRAINT "FK_Posts_Blogs_BlogId" FOREIGN KEY ("BlogId") REFERENCES "Blogs" ("BlogId") ON DELETE CASCADE
);

CREATE INDEX "IX_Posts_BlogId" ON "Posts" ("BlogId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180308135420_InitialCreate', '2.0.1-rtm-125');

