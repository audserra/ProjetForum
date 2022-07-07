import { Comment } from "./comment";

export class Topic{

    public Id : number;
    public CreationDate : Date;
    public ModificationDate : Date;
    public Title : string;
    public Author : string;

    public Comments : Comment[];
    
    constructor(id : number, creationDate : Date, modificationDate : Date, title : string, author : string, comments : Comment[]){
        this.Id = id;
        this.CreationDate = creationDate;
        this.ModificationDate = modificationDate;
        this.Title = title;
        this.Author = author;
        this.Comments = comments;
    }
}