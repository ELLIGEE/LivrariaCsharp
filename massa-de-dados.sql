insert into public."Livro" ("Titulo" , ano_publicacao) values ('Dom Quixote', 1605);
insert into public."Livro" ("Titulo" , ano_publicacao) values ('Cem Anos de Solidão', 1967);
insert into public."Livro" ("Titulo" , ano_publicacao) values ('Good Omens', 1990);
insert into public."Livro" ("Titulo" , ano_publicacao) values ('The Talisman', 1984);
insert into public."Livro" ("Titulo" , ano_publicacao) values ('The Cuckoos Calling', 2013);

insert into public."Autor" ("Nome", "Nacionalidade") values ('Miguel de Cervantes', 'Espanhol');
insert into public."Autor" ("Nome", "Nacionalidade") values ('George Orwell', 'Britânico');
insert into public."Autor" ("Nome", "Nacionalidade") values ('Gabriel García Márquez', 'Colombiano');
insert into public."Autor" ("Nome", "Nacionalidade") values ('Neil Gaiman', 'Britânico');
insert into public."Autor" ("Nome", "Nacionalidade") values ('Terry Pratchett', 'Britânico');
insert into public."Autor" ("Nome", "Nacionalidade") values ('Stephen King', 'Britânico');
insert into public."Autor" ("Nome", "Nacionalidade") values ('Peter Straub', 'Americano');
insert into public."Autor" ("Nome", "Nacionalidade") values ('Robert Galbraith', 'Britânico');
insert into public."Autor" ("Nome", "Nacionalidade") values ('J.K. Rowling', 'Britânico');

insert into public."LivroAutor"  ( "LivroId","AutorId" ) values (1,1);
insert into public."LivroAutor"  ( "LivroId","AutorId" ) values (2,3);
insert into public."LivroAutor"  ( "LivroId","AutorId") values (3,4);
insert into public."LivroAutor"  ( "LivroId","AutorId") values (3,5);
insert into public."LivroAutor"  ( "LivroId","AutorId") values (4,6);
insert into public."LivroAutor"  ( "LivroId","AutorId") values (4,7);
insert into public."LivroAutor"  ( "LivroId","AutorId") values (5,8);
insert into public."LivroAutor"  ( "LivroId","AutorId") values (5,9);