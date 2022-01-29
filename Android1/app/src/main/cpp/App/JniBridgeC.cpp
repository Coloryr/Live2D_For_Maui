/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at https://www.live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */

#include "JniBridgeC.hpp"
#include "LAppDelegate.hpp"
#include "LAppPal.hpp"
#include "LAppView.hpp"
#include "LAppLive2DManager.hpp"
#include "LAppModel.hpp"
#include <CubismFramework.hpp>
#include <string.h>

using namespace Csm;

typedef void (moveTaskToBack)();
typedef char *(loadFile)(const char *filePath, unsigned int *outSize);

moveTaskToBack* _moveTaskToBack;
loadFile* _loadFile;

char *JniBridgeC::LoadFileAsBytesFromJava(const char *filePath, unsigned int *outSize)
{
    return _loadFile(filePath, outSize);
}

void JniBridgeC::MoveTaskToBack()
{
    // アプリ終了
    _moveTaskToBack();
}

extern "C"
{
    void SetMoveTaskToBackCall(moveTaskToBack* call)
    {
        _moveTaskToBack = call;
    }

    void SetLoadFileCall(loadFile* call)
    {
        _loadFile = call;
    }

    const char *GetExpression(int index)
    {
        LAppLive2DManager *l2d = LAppLive2DManager::GetInstance();
        LAppModel *model = l2d->GetModel(0);

        Csm::csmString data1 = model->GetExpression(index);

        return data1.GetRawString();
    }

    const char *GetMotion(int index)
    {
        LAppLive2DManager *l2d = LAppLive2DManager::GetInstance();
        LAppModel *model = l2d->GetModel(0);

        Csm::csmString data1 = model->GetMotion(index);

        return data1.GetRawString();
    }

    int GetExpressionSize()
    {
        LAppLive2DManager *l2d = LAppLive2DManager::GetInstance();
        LAppModel *model = l2d->GetModel(0);

        if (model == nullptr)
        {
            return 0;
        }

        return model->GetExpressionSize();
    }

    int GetMotionSize()
    {
        LAppLive2DManager *l2d = LAppLive2DManager::GetInstance();
        LAppModel *model = l2d->GetModel(0);

        if (model == nullptr)
        {
            return 0;
        }

        return model->GetMotionSize();
    }

    void StartMotion(const char *group, int no, int priority)
    {
        LAppLive2DManager *l2d = LAppLive2DManager::GetInstance();
        LAppModel *model = l2d->GetModel(0);

        model->StartMotion(group, no, priority);
    }

    void StartExpressions(const char *name)
    {
        LAppLive2DManager *l2d = LAppLive2DManager::GetInstance();
        LAppModel *model = l2d->GetModel(0);

        model->SetExpression(name);
    }

    void ChangeModel()
    {
        LAppDelegate::GetInstance()->GetView()->changeModel();
    }

    void OnStart()
    {
        LAppDelegate::GetInstance()->OnStart();
    }

    void OnPause()
    {
        LAppDelegate::GetInstance()->OnPause();
    }

    void OnStop()
    {
        LAppDelegate::GetInstance()->OnStop();
    }

    void OnDestroy()
    {
        LAppDelegate::GetInstance()->OnDestroy();
    }

    void OnSurfaceCreated()
    {
        LAppDelegate::GetInstance()->OnSurfaceCreate();
    }

    void OnSurfaceChanged(int width, int height)
    {
        LAppDelegate::GetInstance()->OnSurfaceChanged(width, height);
    }

    void OnDrawFrame()
    {
        LAppDelegate::GetInstance()->Run();
    }

    void OnTouchesBegan(float pointX, float pointY)
    {
        LAppDelegate::GetInstance()->OnTouchBegan(pointX, pointY);
    }

    void OnTouchesEnded(float pointX, float pointY)
    {
        LAppDelegate::GetInstance()->OnTouchEnded(pointX, pointY);
    }

    void OnTouchesMoved(float pointX, float pointY)
    {
        LAppDelegate::GetInstance()->OnTouchMoved(pointX, pointY);
    }

    void SetPos(float pointX, float pointY)
    {
        LAppLive2DManager *manager = LAppLive2DManager::GetInstance();
        manager->x = pointX;
        manager->y = pointY;
    }

    void SetScale(float scale)
    {
        LAppLive2DManager *manager = LAppLive2DManager::GetInstance();
        manager->scale = scale;
    }

    void SetPosX(float data)
    {
        LAppLive2DManager *manager = LAppLive2DManager::GetInstance();
        manager->x = data;
    }

    void SetPosY(float data)
    {
        LAppLive2DManager *manager = LAppLive2DManager::GetInstance();
        manager->y = data;
    }
}
