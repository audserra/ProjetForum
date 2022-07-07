import { Comment } from "./comment";

export class Topic{

    public id : number;
    public creationDate : Date;
    public modificationDate : Date;
    public title : string;
    public author : string;

    public comments : Comment[];
    
    constructor(id : number, creationDate : Date, modificationDate : Date, title : string, author : string, comments : Comment[]){
        this.id = id;
        this.creationDate = creationDate;
        this.modificationDate = modificationDate;
        this.title = title;
        this.author = author;
        this.comments = comments;
    }
}