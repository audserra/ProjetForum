import { Component, OnInit } from '@angular/core';
import { TopicService } from 'src/app/services/topic.service';
import { Topic } from 'src/models/topic';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {

  topics : Topic[] = [];
  
  constructor(private topicService : TopicService) { }

  ngOnInit(): void {
    this.topicService.getAllTopics().subscribe(response =>{
      this.topics = response;
      console.log(this.topics)
    })
  }
}
