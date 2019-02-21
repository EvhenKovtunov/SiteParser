export class DataModel {
    id: number;
    text: string;
    word: string;
    constructor(data?){
        if (data == null || data === 'undefined') {
            return;
        }
        this.id = data.id;
        this.text = data.text || '';
        this.word = data.word || '';
    }
}