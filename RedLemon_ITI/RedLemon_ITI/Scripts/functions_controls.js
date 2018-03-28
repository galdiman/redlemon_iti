function RenderContorl(container, activityExtras) {
    if (activityExtras != undefined && activityExtras.length > 0) {
        $.each(activityExtras, function (idx, activityExtra) {
            if (activityExtra.ExtraTypeInformationId == 1) //Div
            {
                container.append(RenderDiv(activityExtra));
            }
            if (activityExtra.ExtraTypeInformationId == 3) //Control
            {
                RenderControlByType(container, activityExtra);
            }
        });
    }
}

function RenderControlByType(container, activityExtra) {
    if (activityExtra.Key == "image")
        container.append(RenderImg(activityExtra));

    if (activityExtra.Key == "imageCircle")
        container.append(RenderImageCircle(activityExtra));

    if (activityExtra.Key == "inputs")
        RenderInputs(container, activityExtra);

    if (activityExtra.Key == "input")
        RenderInput(container, activityExtra);

    if (activityExtra.Key == "ranking")
        RenderRanking(container, activityExtra);

    if (activityExtra.Key == "rankingOptional")
        RenderRankingOptional(container, activityExtra);

    if (activityExtra.Key == "icon")
        RenderIcon(container, activityExtra);

    if (activityExtra.Key == "buttonIcon") {
        RenderButtonIcon(container, activityExtra);

    }

}

function RenderDiv(activityExtra) {
    var div = $('<div id="' + activityExtra.Value + '"></div>');

    if (activityExtra.HasChildren && activityExtra.Children[0].ExtraTypeInformationId == 6)
        div.attr(activityExtra.Children[0].Key, activityExtra.Children[0].Value);

    if (activityExtra.HasChildren)
        RenderContorl(div, activityExtra.Children);
    return div;
}

function RenderImg(activityExtra) {
    return $('<img class="img-rounded" src="' + activityExtra.Value + '" />');
}

function RenderImageCircle(activityExtra) {
    return $('<img class="img-circle" src="' + activityExtra.Value + '" style="border:2px solid black; margin-left:5px;" />');
}

function RenderInputs(container, activityExtra) {
    var ninputs = parseInt(activityExtra.Value);
    for (i = 0; i < ninputs; i++) {
        container.append($('<input type="text" class="form-control" id="txtAnswer_' + i + '" placeholder="Type your comments here..." />'));
    }
}

function RenderInput(container, activityExtra) {
    container.append($('<div class="form-group" style="display:inline-block;"><label for="txtAnswer_' + activityExtra.Id + '">' + activityExtra.Value + '</label><input type="text" class="form-control" id="txtAnswer_' + activityExtra.Id + '" style="width:180px;" /></div>'));
}

function RenderRanking(container, activityExtra) {
    container.append($('<div class="form-group"><input type="text" class="form-control" id="txtAnswer_' + i + '" style="width:35px !important; margin-right:10px;display:inline-block;"/><label for="txtAnswer_' + activityExtra.Id + '" style="display:inline-block;">' + activityExtra.Value + '</label></div>'));
}

function RenderRankingOptional(container, activityExtra) {
    container.append($('<div class="form-group"><input type="text" class="form-control" id="txtAnswer_' + activityExtra.Id + '" style="width:35px !important; margin-right:10px;display:inline-block;"/><input  type="text" id="txtAnswerComments_' + activityExtra.Id + '" placeholder="' + activityExtra.Value + '" class="form-control" style="display:inline-block;" /></div>'));
}

function RenderIcon(container, activityExtra) {
    container.append($('<div class="form-group" style="display:inline-block;margin-left:15px;margin-right:12px;"><span class="' + activityExtra.Value + '" ></span></div>'));
}

function RenderButtonIcon(container, activityExtra) {
    var btnName = "btn_" + activityExtra.Id;
    var div = $("<div class='form-group' style='display:inline-block;margin-left:15px'></div>");

    var action = "";
    if (activityExtra.HasChildren) {
        var actionObj = activityExtra.Children[0];
        action = actionObj.Key + "=" + actionObj.Value;
    }

    var btn = $('<a href="#" id="' + btnName + '" class="btn btn-primary" ' + action + '><span class="' + activityExtra.Value + '" ></span></a>');

    div.append(btn);
    container.append(div);
}