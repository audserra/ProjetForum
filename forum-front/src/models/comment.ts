export class Comment{

    public id : number;
    public creationDate : Date;
    public modificationDate : Date;
    public user : string;
    public content : string;
    public topicId : number
    
    constructor(id : number, creationDate : Date, modificationDate : Date, user : string, content : string, topicId : number){
        this.id = id;
        this.creationDate = creationDate;
        this.modificationDate = modificationDate;
        this.user = user;
        this.content = content;
        this.topicId = topicId;
    }
}