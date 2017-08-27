/*
 *
 * JOOOOOOOYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
 * THIS IS WHY YOU USE REACT
 */

class QuestionForm {

    constructor() {
        this.qstnGrp = document.getElementById("questionGroup");
        this.qstnBtn = document.getElementById("addQuestionBtn");
        this.setActive = this.setActive.bind(this);
    }

    addNewPanel(qstnCount) {
        let div = QuestionForm.createFormGroup(qstnCount);
        let qIn = QuestionForm.createQuestionInput(qstnCount);
        let aIn = QuestionForm.createAnswerInput(qstnCount);
        let qLbl = QuestionForm.createQuestionLabel(qstnCount);
        div.appendChild(qLbl);
        div.appendChild(qIn);
        div.appendChild(aIn);
        qstnCount++;
        this.qstnGrp.appendChild(div);
    }

    setActive(index) {
        let nodes = this.qstnGrp.childNodes;
        for (var node in nodes) {
            if (nodes[node].tagName == "DIV") {
                if (nodes[node].id == `pane-${index}`) {
                    nodes[node].classList.remove("hidden");
                    nodes[node].classList.add("tab-pane");
                }
                else {
                    nodes[node].classList.remove("tab-pane");
                    nodes[node].classList.add("hidden");
                }
            }
        }
    }

    static createFormGroup(qstnCount) {
        let div = document.createElement("div");
        div.id = `pane-${qstnCount}`;
        div.className = "tab-pane";
        return div;
    }

    static createQuestionInput(qstnCount) {
        let qstnInput = document.createElement("input");
        qstnInput.id = `question${qstnCount}`;
        qstnInput.className = "form-control";
        qstnInput.placeholder = `Question #${qstnCount}`;
        return qstnInput;
    }

    static createAnswerInput(qstnCount) {
        let ansInput = document.createElement("input");
        ansInput.id = `answer${qstnCount}`;
        ansInput.className = "form-control";
        ansInput.placeholder = `Answer for Question #${qstnCount}`;
        return ansInput;
    }

    static createQuestionLabel(qstnCount) {
        let qstnLabel = document.createElement("label");
        qstnLabel.id = `questionLabel${qstnCount}`;
        qstnLabel.className = "form-label h5";
        qstnLabel.innerText = `Question ${qstnCount}`;
        return qstnLabel;
    }


}

class QuestionNavigation {

    constructor() {
        this.qstnNav = document.getElementById("questionNav");
        this.tabBtn = document.getElementById("newTabBtn");
        this.addLi = document.getElementById("newTabLi");
        this.setActive = this.setActive.bind(this);
        this.createQuestionTab = this.createQuestionTab.bind(this);
    }

    createQuestionTab(count) {
        let li = document.createElement("li");
        let a = document.createElement("a");
        this.setActive(li);
        a.innerText = count;
        li.appendChild(a);
        this.qstnNav.insertBefore(li, this.addLi);
        return a;

    }

    setActive(node) {
        let nodes = this.qstnNav.childNodes;
        for (var item in nodes) {
            if (nodes[item].tagName == "LI") {
                nodes[item].classList.remove("active");
            }
        }
        node.classList.add("active");
    }

}

class FormManager {
    constructor() {
        this.qstnCount = 1;
        this.panel = new QuestionForm();
        this.nav = new QuestionNavigation();
        this.createNewTab = this.createNewTab.bind(this);
        this.nav.tabBtn.addEventListener("click", this.createNewTab);
        this.panel.qstnBtn.addEventListener("click", () => {
            this.panel.addNewPanel(this.qstnCount);

            this.qstnCount++;
        });
    }

    setActive(tab) {
        this.nav.setActive(tab);
        this.panel.setActive(tab.textContent);
    }

    createNewTab() {
        if (this.qstnCount == 10) {
            
        }
        let a = this.nav.createQuestionTab(this.qstnCount);
        a.addEventListener("click", () => {
            this.setActive(a.parentElement);
        });
        this.panel.addNewPanel(this.qstnCount);
        this.setActive(a.parentElement);
        this.qstnCount++;
    }

    init() {
        this.createNewTab();
    }
}


let btnsGrp = document.getElementById("buttonsGroup");
let formManager = new FormManager();

function init() {
    formManager.init();
}


window.addEventListener("load", init);

window.onsubmit = (evt) => {
    evt.preventDefault();
    let nodes = qstnGrp.childNodes;
    for (var grp in nodes) {
        console.log(nodes[grp]);
        for (var item in grp.childNodes) {
            console.log(grp.childNodes[item]);
        }
    }
};