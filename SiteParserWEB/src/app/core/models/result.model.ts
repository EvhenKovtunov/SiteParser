export class ResultModel {
    id: number;
    sentence: string;
    word: string;
    count: number;
    constructor(data?){
        if (data == null || data === 'undefined') {
            return;
        }
        this.id = data.id;
        this.sentence = data.sentence || '';
        this.word = data.word || '';
        this.count = data.count || '';
    }
}