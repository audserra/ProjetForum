import { Component, OnInit } from '@angular/core';
import { TopicService } from 'src/app/services/topic.service';
import { Topic } from 'src/models/topic';

@Component({
  selector: 'app-topic',
  templateUrl: './topicList.component.html',
  styleUrls: ['./topicList.component.css']
})
export class TopicListComponent implements OnInit {

  topics : Topic[] = [];
  
  constructor(private topicService : TopicService) { }

  ngOnInit(): void {
    this.loadTopics();
  }

  loadTopics(): void {
    this.topicService.getAllTopics().subscribe(response =>{
      this.topics = response;
    });
  }

  deleteTopic(event : Event, topicId : number){
    event.stopPropagation();
    if(confirm("Etes vous sûr de vouloir supprimer ce topic ? Cette action est irréversible, et entraînera la suppression de tous les commentaires associés !" )){
        this.topicService.deleteTopic(topicId).subscribe(response =>{
          console.log(topicId);
          this.loadTopics();
        });
    }
   }
}
