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

  // Code laissé pour l'exemple
  loadTopics(): void {
    this.topicService.getAllTopics().subscribe({
      next: (response) => {
          this.topics = response;
      },
      error : (err) => {

      },
      complete: () => {

      }
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

   handleChildEvent () {
    this.loadTopics();
  }
}
