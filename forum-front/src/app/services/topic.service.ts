import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Topic } from 'src/models/topic';

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(private httpClient : HttpClient) { }

  getAllTopics() : Observable<Topic[]>{
    return this.httpClient.get<Topic[]>(`${environment.apiBaseUrl}/Topic`)
  }

  getTopicById(id : number) : Observable<Topic>{
    return this.httpClient.get<Topic>(`${environment.apiBaseUrl}/Topic/${id}`)
  }

  createTopic(topic: Topic) {
    return this.httpClient.post(`${environment.apiBaseUrl}/Topic`, topic)
  }

  deleteTopic(id : number){
    return this.httpClient.delete(`${environment.apiBaseUrl}/Topic/${id}`)
  }
}
