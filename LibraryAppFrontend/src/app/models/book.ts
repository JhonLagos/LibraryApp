import { Author } from "./author";
import { Editorial } from "./editorial";

export class Book {
    id: number;
    title: string;
    year: number;
    genre: string;
    numberPages: number;
    author: Author;
    editorial: Editorial;
}