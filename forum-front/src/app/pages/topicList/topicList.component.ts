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

}
