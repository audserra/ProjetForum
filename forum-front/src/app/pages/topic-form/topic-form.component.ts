import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TopicService } from 'src/app/services/topic.service';
import { Topic } from 'src/models/topic';

@Component({
  selector: 'app-topic-form',
  templateUrl: './topic-form.component.html',
  styleUrls: ['./topic-form.component.css']
})
export class TopicFormComponent implements OnInit {

  topicForm:FormGroup;

  constructor(private topicService : TopicService) { 

    this.topicForm = new FormGroup({
      authorControl : new FormControl(null, Validators.required),
      titleControl : new FormControl(null, Validators.required)
    });
  }

  ngOnInit(): void {
  }

  addTopic() : void{
    let topic = new Topic(undefined, undefined, undefined, this.topicForm.get("titleControl").value, this.topicForm.get("authorControl").value, undefined);
    console.log(topic);

    this.topicService.createTopic(topic).subscribe((data: string) => {});

    this.topicForm.reset();
  }

}
