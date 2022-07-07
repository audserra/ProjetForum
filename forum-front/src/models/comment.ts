export class Comment{

    public Id : number;
    public CreationDate : Date;
    public ModificationDate : Date;
    public User : string;
    public Content : string;
    public TopicId : number
    
    constructor(id : number, creationDate : Date, modificationDate : Date, user : string, content : string, topicId : number){
        this.Id = id;
        this.CreationDate = creationDate;
        this.ModificationDate = modificationDate;
        this.User = user;
        this.Content = content;
        this.TopicId = topicId;
    }
}