export class Note {

    constructor(
        
        public id?: number,

        public name?: string,

        public text?: string,

        public lastChange?: Date,

        public noteCategoryId?: number
    ) { }
}