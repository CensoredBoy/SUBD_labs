insert into genres (genre_id, name) values 
                                        (1, 'Rock'),
                                        (2, 'Pop'),
                                        (3, 'R&B'),
                                        (4, 'Folk'),
                                        (5, 'Rap'),
                                        (6, 'Indie'),
                                        (7, 'Alternative')
on conflict do nothing;

insert into media (media_id, type) values 
                                       (1, 'Disk'),
                                       (2, 'Vinyl'),
                                       (3, 'CD'),
                                       (4, 'Cloud')
on conflict do nothing;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241123094557_addGenreAndMediaType', '9.0.1') on conflict do nothing;

COMMIT;

