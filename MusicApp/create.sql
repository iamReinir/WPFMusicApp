CREATE TABLE IF NOT EXISTS Song (
    Id TEXT PRIMARY KEY,
    Path TEXT,
    PublishedAt DATETIME,
    ChannelId TEXT,
    Title TEXT,
    Description TEXT,
    Thumbnail_default_Url TEXT,
    Thumbnail_default_Width INTEGER,
    Thumbnail_default_Height INTEGER,
    Thumbnail_medium_Url TEXT,
    Thumbnail_medium_Width INTEGER,
    Thumbnail_medium_Height INTEGER,
    Thumbnail_high_Url TEXT,
    Thumbnail_high_Width INTEGER,
    Thumbnail_high_Height INTEGER,
    ChannelTitle TEXT,
    LiveBroadcastContent TEXT,
    PublishTime DATETIME,
    CurrentState INTEGER
);

